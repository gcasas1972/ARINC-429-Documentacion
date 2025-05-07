// maindlg.h : interface of the CMainDlg class
//
/////////////////////////////////////////////////////////////////////////////

#if !defined(AFX_MAINDLG_H__48CC6312_2882_4CA5_ADEF_49863B653C6A__INCLUDED_)
#define AFX_MAINDLG_H__48CC6312_2882_4CA5_ADEF_49863B653C6A__INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000

const short ID_TIMER = 1;

class CMainDlg : public CDialogImpl<CMainDlg>
{
public:
	enum { IDD = IDD_MAINDLG };

	BEGIN_MSG_MAP(CMainDlg)
		MESSAGE_HANDLER(WM_INITDIALOG,		OnInitDialog)
		MESSAGE_HANDLER(WM_DESTROY,			OnDestory)
		MESSAGE_HANDLER(WM_TIMER,			OnTimer)
		COMMAND_ID_HANDLER(IDCANCEL,		OnCancel)
		COMMAND_ID_HANDLER(IDC_CMDOPEN,		OnOpen)
		COMMAND_ID_HANDLER(IDC_CMDRUN,		OnRun)
		COMMAND_ID_HANDLER(IDC_CMDSTOP,		OnStop)
		COMMAND_ID_HANDLER(IDC_CMDMONITOR,	OnMonitor)
		COMMAND_HANDLER(IDC_COMBO1, CBN_SELCHANGE, OnComboChange)
	END_MSG_MAP()

	LRESULT OnInitDialog(UINT /*uMsg*/, WPARAM /*wParam*/, LPARAM /*lParam*/, BOOL& /*bHandled*/)
	{
		// center the dialog on the screen
		CenterWindow();

		// set icons
		HICON hIcon = (HICON)::LoadImage(_Module.GetResourceInstance(), MAKEINTRESOURCE(IDR_MAINFRAME), 
			IMAGE_ICON, ::GetSystemMetrics(SM_CXICON), ::GetSystemMetrics(SM_CYICON), LR_DEFAULTCOLOR);
		SetIcon(hIcon, TRUE);
		HICON hIconSmall = (HICON)::LoadImage(_Module.GetResourceInstance(), MAKEINTRESOURCE(IDR_MAINFRAME), 
			IMAGE_ICON, ::GetSystemMetrics(SM_CXSMICON), ::GetSystemMetrics(SM_CYSMICON), LR_DEFAULTCOLOR);
		SetIcon(hIconSmall, FALSE);

		// Automation return value.
		HRESULT hr;	

		// Initializes the COM library.
		hr = OleInitialize(NULL);

		// Creates a new running instance of the CoPilot Application Object.
		hr = _pCopilot.CreateInstance(L"BallardCoPilot.CopilotShell.1");
		if(FAILED(hr) || NULL==_pCopilot)
		{
			MessageBox(_T("Unable to create CoPilot. Application will close."),_T("Error"));
			EndDialog(1);
		}

		// Init the status text
		SetDlgItemText(IDC_TEXTSTATUS,_T("Open a project..."));
		// Init the board combo box
		SendMessage(GetDlgItem(IDC_COMBO1),CB_RESETCONTENT,0,0);
		// Clear the outputlist
		SendMessage(GetDlgItem(IDC_OUTPUTLIST),LB_RESETCONTENT,0,0);
		// Clear the monreclist
		SendMessage(GetDlgItem(IDC_MONRECLIST),LB_RESETCONTENT,0,0);

		return TRUE;
	}

	LRESULT OnDestory(UINT /*uMsg*/, WPARAM /*wParam*/, LPARAM /*lParam*/, BOOL& /*bHandled*/)
	{
		StopTimer();
		/*
		 Optionally stop the project and Close CoPilot
		_pCopilot->Stop();
		_pCopilot->Quit();
		*/

		// Close the COM library.
		OleUninitialize();

		return 0;
	}

	LRESULT OnCancel(WORD /*wNotifyCode*/, WORD wID, HWND /*hWndCtl*/, BOOL& /*bHandled*/)
	{
		EndDialog(wID);
		return 0;
	}

	LRESULT OnComboChange(UINT uMsg, WPARAM wParam, HWND hCtrl, BOOL& bHandled)
	{
		// Clear the monreclist
		SendMessage(GetDlgItem(IDC_MONRECLIST),LB_RESETCONTENT,0,0);

		RefreshOutput();

		return 0;
	}
	
	LRESULT OnTimer(UINT uMsg, WPARAM wParam, LPARAM lParam, BOOL& bHandled)
	{
		VARIANT_BOOL bRunning=VARIANT_FALSE;
		_pCopilot->get_Running(&bRunning);

		if (bRunning)
		{
			RefreshOutput();
		}

		return 0;
	}

	LRESULT OnOpen(WORD /*wNotifyCode*/, WORD /*wID*/, HWND /*hWndCtl*/, BOOL& /*bHandled*/)
	{
		//	If running then stop
		VARIANT_BOOL bRunning=VARIANT_FALSE;
		_pCopilot->get_Running(&bRunning);
		if (bRunning)
		{
			_pCopilot->Stop();
		}
		
		//	Close the current project
		_pCopilot->Close(false);

		//
		//	Browse for new project
		//

		TCHAR szPath[_MAX_PATH];
		_stprintf(szPath,_T(""));

		OPENFILENAME ofn;
		ZeroMemory(&ofn,sizeof(ofn));
		ofn.lpstrFilter		= _T("CoPilot Projects (*.CPJ)\0*.CPJ\0"); 
		ofn.lStructSize		= sizeof(OPENFILENAME); 
		ofn.hwndOwner		= m_hWnd; 
		ofn.hInstance		= _Module.GetModuleInstance();
		ofn.nFilterIndex	= 1;
		ofn.lpstrFile		= szPath; 
		ofn.nMaxFile		= _MAX_PATH; 
		ofn.lpstrInitialDir	= NULL; 
		ofn.lpstrTitle		= _T("Open Project");
		ofn.Flags			= OFN_NOCHANGEDIR | OFN_PATHMUSTEXIST; 

		BOOL bFileSelected = GetOpenFileName(&ofn);

		if (bFileSelected)
		{
			//	Open new project
			_pCopilot->Open(CComBSTR(ofn.lpstrFile), true);

			//	Update status text
			_pCopilot->get_ProjectName(&_bstrProjName);
			TCHAR szStatus[_MAX_PATH];
			_stprintf(szStatus,_T("%ls - Stopped..."),_bstrProjName);
			SetDlgItemText(IDC_TEXTSTATUS,szStatus);
		}

		InitCombo();

		return 0;
	}

	LRESULT OnRun(WORD /*wNotifyCode*/, WORD wID, HWND /*hWndCtl*/, BOOL& /*bHandled*/)
	{
		// Clear the monreclist

		CComBSTR bstrCurProject;
		_pCopilot->get_CurProject(&bstrCurProject);

		if (bstrCurProject.Length())
		{
			_pCopilot->Run();

			TCHAR szStatus[_MAX_PATH];
			_stprintf(szStatus,_T("%ls - Running"),_bstrProjName);
			SetDlgItemText(IDC_TEXTSTATUS,szStatus);

			StartTimer();
		}
		else
		{
			MessageBox(_T("No project is open."),_T("Error"));
		}

		return 0;
	}

	LRESULT OnStop(WORD /*wNotifyCode*/, WORD wID, HWND /*hWndCtl*/, BOOL& /*bHandled*/)
	{
		StopTimer();

		_pCopilot->Stop();

		RefreshOutput();

		TCHAR szStatus[_MAX_PATH];
		_stprintf(szStatus,_T("%ls - Stopped..."),_bstrProjName);
		SetDlgItemText(IDC_TEXTSTATUS,szStatus);


		return 0;
	}

	LRESULT OnMonitor(WORD /*wNotifyCode*/, WORD wID, HWND /*hWndCtl*/, BOOL& /*bHandled*/)
	{
		TCHAR szItem[_MAX_PATH];

		// Clear the outputlist
		SendMessage(GetDlgItem(IDC_MONRECLIST),LB_RESETCONTENT,0,0);

		int iIndex = SendMessage(GetDlgItem(IDC_COMBO1),CB_GETCURSEL,0,0);
		if (iIndex > 0)
		{
			// CARD
			int iItemData = SendMessage(GetDlgItem(IDC_COMBO1),CB_GETITEMDATA,iIndex,0);
			COPILOT::IBTCardCollectionPtr pCards;
			_pCopilot->get_Cards(&pCards);

			COPILOT::IBTPublicCopilotCardPtr pCard;
			if (pCards) pCards->get_Item(CComVariant(iItemData), &pCard);

			// MONITOR
			COPILOT::IBTMonitorCollectionPtr pMonitors;

			//Assumes Core 0 only
			int iCoreNum=0;
			if (pCard)
			{
				pCard->get_Monitors(iCoreNum,&pMonitors);
				long lMonCount;
				pMonitors->get_Count(&lMonCount);
				for (long lMonIndex=1; lMonIndex<=lMonCount; lMonIndex++)
				{
					COPILOT::IBTPublicCopilotMonitorPtr	pMonitor;
					pMonitors->get_Item(CComVariant(lMonIndex), &pMonitor);

					CComBSTR bstrMon;
					pMonitor->get_Description(&bstrMon);
					_stprintf(szItem,_T("%ls"),bstrMon);
					SendMessage(GetDlgItem(IDC_MONRECLIST),LB_ADDSTRING,0,(LPARAM)szItem);

					// 1553 RECORD
					COPILOT::IBT1553RecCollectionPtr pMon1553Recs;

					pMonitor->Record1553s(0, &pMon1553Recs);// Only gets records for channel 0
					long lRecCount;
					pMon1553Recs->get_Count(&lRecCount);
					long lRecIndex=1;
					for (lRecIndex=1; lRecIndex<=lRecCount; lRecIndex++)
					{
						COPILOT::IBTMon1553RecPtr p1553Rec;
						pMon1553Recs->get_Item(lRecIndex, &p1553Rec);
						long lCwd1, lSwd1, lErrVal;
						p1553Rec->get_cwd1(&lCwd1);
						p1553Rec->get_Swd1(&lSwd1);
						p1553Rec->get_ErrorVal(&lErrVal);
						_stprintf(szItem,_T("%04d Cwd1:%04X Swd1:%04X"),lRecIndex,lCwd1,lSwd1);
						if (lErrVal & 0x8000)	_tcscat(szItem," No Response!");
						SendMessage(GetDlgItem(IDC_MONRECLIST),LB_ADDSTRING,0,(LPARAM)szItem);
					} // 1553 RECORD

					// 429 RECORD
					COPILOT::IBT429RecCollectionPtr pMon429Recs;
					pMonitor->get_Record429s(&pMon429Recs);
					pMon429Recs->get_Count(&lRecCount);
					for (lRecIndex=1; lRecIndex<=lRecCount; lRecIndex++)
					{
						COPILOT::IBTMon429RecPtr p429Rec;
						pMon429Recs->get_Item(lRecIndex, &p429Rec);
						long lMsgVal;
						short nLabelNum;
						p429Rec->get_LabelNum(&nLabelNum);
						p429Rec->get_MsgVal(&lMsgVal);
						_stprintf(szItem,_T("%04d Label:%03o %08X"),lRecIndex,nLabelNum,lMsgVal);
						SendMessage(GetDlgItem(IDC_MONRECLIST),LB_ADDSTRING,0,(LPARAM)szItem);
					} // 429 RECORD

					// 708 RECORD
					COPILOT::IBT708RecCollectionPtr pMon708Recs;
					pMonitor->get_Record708s(0, &pMon708Recs);// Only gets records for channel 0
					pMon708Recs->get_Count(&lRecCount);
					for (lRecIndex=1; lRecIndex<=lRecCount; lRecIndex++)
					{
						COPILOT::IBTMon708RecPtr p708Rec;
						pMon708Recs->get_Item(lRecIndex, &p708Rec);
						short nDataCount;
						p708Rec->get_DataCount(&nDataCount);
						_stprintf(szItem,_T("%04d Data Count:%d"),lRecIndex,nDataCount);
						SendMessage(GetDlgItem(IDC_MONRECLIST),LB_ADDSTRING,0,(LPARAM)szItem);
					} // 708 RECORD

					// AFDX RECORD
					COPILOT::IBTAFDXRecCollectionPtr pMonAFDXRecs;
					pMonitor->get_RecordAFDXs(&pMonAFDXRecs);// Only gets records for channel 0
					if (pMonAFDXRecs)
					{
						pMonAFDXRecs->get_Count(&lRecCount);
						for (lRecIndex=1; lRecIndex<=lRecCount; lRecIndex++)
						{
							COPILOT::IBTMonAFDXRecPtr pAFDXRec;
							pMonAFDXRecs->get_Item(lRecIndex, &pAFDXRec);
							USHORT nDataCount=1600;
							unsigned char data[1600];
							pAFDXRec->GetPacket(&nDataCount,data);
							_stprintf(szItem,_T("%04d Data Count:%d"),lRecIndex,nDataCount);
							SendMessage(GetDlgItem(IDC_MONRECLIST),LB_ADDSTRING,0,(LPARAM)szItem);
						} // AFDX RECORD
					}

				}// MONITOR
			}
		}

		return 0;
	}

	void StartTimer()
	{
		StopTimer();
		SetTimer(ID_TIMER, 1000);
	}

	void StopTimer()
	{
		KillTimer(ID_TIMER);
	}

	void InitCombo()
	{
		USES_CONVERSION;

		HRESULT hr;
		int iItem=-1;

		// Clear the outputlist
		SendMessage(GetDlgItem(IDC_OUTPUTLIST),LB_RESETCONTENT,0,0);

		// Clear the monreclist
		SendMessage(GetDlgItem(IDC_MONRECLIST),LB_RESETCONTENT,0,0);

		// Clear the combo
		SendMessage(GetDlgItem(IDC_COMBO1),CB_RESETCONTENT,0,0);

		// Set the top item
		iItem = SendMessage(GetDlgItem(IDC_COMBO1),CB_ADDSTRING,0,(LPARAM)"Select A Card");
		SendMessage(GetDlgItem(IDC_COMBO1),CB_SETCURSEL,iItem,0);

		// Add each card
		COPILOT::IBTCardCollectionPtr pCards;
		hr = _pCopilot->get_Cards(&pCards);
		if (SUCCEEDED(hr))
		{
			long lCount;
			pCards->get_Count(&lCount);
			for (long index=1; index<=lCount; index++)
			{
				COPILOT::IBTPublicCopilotCardPtr pCard;
				hr = pCards->get_Item(CComVariant(index), &pCard);
				if (SUCCEEDED(hr) && NULL!=pCard)
				{
					CComBSTR bstrDescription;
					pCard->get_Description(&bstrDescription);

					iItem = SendMessage(GetDlgItem(IDC_COMBO1),CB_ADDSTRING,0,(LPARAM)W2T(bstrDescription));
					SendMessage(GetDlgItem(IDC_COMBO1),CB_SETITEMDATA,iItem,index);
				}
			}
		}
	}

	void RefreshOutput()
	{
		TCHAR szItem[_MAX_PATH];

		// Clear the outputlist
		SendMessage(GetDlgItem(IDC_OUTPUTLIST),LB_RESETCONTENT,0,0);

		int iIndex = SendMessage(GetDlgItem(IDC_COMBO1),CB_GETCURSEL,0,0);
		if (iIndex > 0)
		{
			// CARD
			int iItemData = SendMessage(GetDlgItem(IDC_COMBO1),CB_GETITEMDATA,iIndex,0);
			COPILOT::IBTCardCollectionPtr pCards;
			_pCopilot->get_Cards(&pCards);

			COPILOT::IBTPublicCopilotCardPtr pCard;
			pCards->get_Item(CComVariant(iItemData), &pCard);
			
			// 1553 CHANNELS
			COPILOT::IBT1553ChanCollectionPtr p1553Chans;
			
			//Assumes Core 0 only
			int iCoreNum=0;
			
			pCard->get_Chan1553s(iCoreNum,&p1553Chans);
			long lChanCount=0;
			if (p1553Chans) p1553Chans->get_Count(&lChanCount);
			for (long lChanIndex=1; lChanIndex<=lChanCount; lChanIndex++)
			{
				COPILOT::IBTPublic1553ChanPtr p1553Chan;
				p1553Chans->get_Item(CComVariant(lChanIndex), &p1553Chan);
				CComBSTR bstrChan;
				p1553Chan->get_Description(&bstrChan);
				_stprintf(szItem,_T("-- %ls"),bstrChan);
				SendMessage(GetDlgItem(IDC_OUTPUTLIST),LB_ADDSTRING,0,(LPARAM)szItem);

				// BUS CONTROLLER
				COPILOT::IBTPublic1553BCPtr pBC;
				p1553Chan->get_BC(&pBC);
				{
					CComBSTR bstrBC;
					pBC->get_Description(&bstrBC);
					_stprintf(szItem,_T("  -- %ls"),bstrBC);
					SendMessage(GetDlgItem(IDC_OUTPUTLIST),LB_ADDSTRING,0,(LPARAM)szItem);

					// BC MESSAGES
					COPILOT::IBT1553BCMsgCollectionPtr pBCMsgs;
					pBC->get_BCMsgs(&pBCMsgs);
					long lMsgCount;
					pBCMsgs->get_Count(&lMsgCount);
					for (long lMsgIndex=1; lMsgIndex<=lMsgCount; lMsgIndex++)
					{
						COPILOT::IBTPublic1553BCMsgPtr pBCMsg;
						pBCMsgs->get_Item(CComVariant(lMsgIndex), &pBCMsg);
						CComBSTR bstrMsg;
						pBCMsg->get_Description(&bstrMsg);
						_stprintf(szItem,_T("    -- %ls"),bstrMsg);
						SendMessage(GetDlgItem(IDC_OUTPUTLIST),LB_ADDSTRING,0,(LPARAM)szItem);

						// FIELDS
						COPILOT::IBT1553FieldCollectionPtr p1553Fields;
						pBCMsg->get_Field1553s(&p1553Fields);
						long lFieldCount;
						p1553Fields->get_Count(&lFieldCount);
						for (long lFieldIndex=1; lFieldIndex<=lFieldCount; lFieldIndex++)
						{
							COPILOT::IBTPublic1553FieldPtr p1553Field;
							p1553Fields->get_Item(CComVariant(lFieldIndex), &p1553Field);
							CComBSTR bstrField;
							p1553Field->get_Description(&bstrField);
							_stprintf(szItem,_T("      -- %ls"),bstrField);
							SendMessage(GetDlgItem(IDC_OUTPUTLIST),LB_ADDSTRING,0,(LPARAM)szItem);
						}// FIELDS

					}// BC MESSAGES

				}// BUS CONTROLLER

				// RTS
				COPILOT::IBT1553RTCollectionPtr pRTs;
				p1553Chan->get_RTs(&pRTs);
				long lRTCount;
				pRTs->get_Count(&lRTCount);
				for (long lRTIndex=1; lRTIndex<=lRTCount; lRTIndex++)
				{
					COPILOT::IBTPublic1553RTPtr pRT;
					pRTs->get_Item(CComVariant(lRTIndex), &pRT);
					CComBSTR bstrRT;
					pRT->get_Description(&bstrRT);
					_stprintf(szItem,_T("    -- %ls"),bstrRT);
					SendMessage(GetDlgItem(IDC_OUTPUTLIST),LB_ADDSTRING,0,(LPARAM)szItem);

					// SAS
					COPILOT::IBT1553SACollectionPtr pSAs;
					pRT->get_SAs(&pSAs);
					long lSACount;
					pSAs->get_Count(&lSACount);
					for (long lSAIndex=1; lSAIndex<=lSACount; lSAIndex++)
					{
						COPILOT::IBTPublic1553SAPtr pSA;
						pSAs->get_Item(CComVariant(lSAIndex), &pSA);
						CComBSTR bstrSA;
						pSA->get_Description(&bstrSA);
						_stprintf(szItem,_T("      -- %ls"),bstrSA);
						SendMessage(GetDlgItem(IDC_OUTPUTLIST),LB_ADDSTRING,0,(LPARAM)szItem);

						// FIELDS
						COPILOT::IBT1553FieldCollectionPtr p1553Fields;
						pSA->get_Field1553s(&p1553Fields);
						long lFieldCount;
						p1553Fields->get_Count(&lFieldCount);
						for (long lFieldIndex=1; lFieldIndex<=lFieldCount; lFieldIndex++)
						{
							COPILOT::IBTPublic1553FieldPtr p1553Field;
							p1553Fields->get_Item(CComVariant(lFieldIndex), &p1553Field);
							CComBSTR bstrField;
							p1553Field->get_Description(&bstrField);
							_stprintf(szItem,_T("        -- %ls"),bstrField);
							SendMessage(GetDlgItem(IDC_OUTPUTLIST),LB_ADDSTRING,0,(LPARAM)szItem);
						}// FIELDS

					}// SAS

				}// RTS

			}// 1553 CHANNELS

			// 429 CHANNELS
			COPILOT::IBT429ChanCollectionPtr p429Chans;

			//Assumes Core 0 only
			pCard->get_Chan429s(iCoreNum,&p429Chans);
			
			lChanCount = 0;
			if (p429Chans) p429Chans->get_Count(&lChanCount);
			for (int lChanIndex=1; lChanIndex<lChanCount; lChanIndex++)
			{
				COPILOT::IBTPublic429ChanPtr p429Chan;
				p429Chans->get_Item(CComVariant(lChanIndex), &p429Chan);
				CComBSTR bstrChan;
				p429Chan->get_Description(&bstrChan);
				_stprintf(szItem,_T("-- %ls"),bstrChan);
				SendMessage(GetDlgItem(IDC_OUTPUTLIST),LB_ADDSTRING,0,(LPARAM)szItem);

				// LABELS
				COPILOT::IBT429MsgCollectionPtr pLabels;
				p429Chan->get_Labels(&pLabels);
				long lLabelCount;
				pLabels->get_Count(&lLabelCount);
				for (long lLabelIndex=1; lLabelIndex<lLabelCount; lLabelIndex++)
				{
					COPILOT::IBTPublic429MsgPtr pLabel;
					pLabels->get_Item(CComVariant(lLabelIndex), &pLabel);
					CComBSTR bstrLabel;
					pLabel->get_Description(&bstrLabel);
					_stprintf(szItem,_T("  -- %ls"),bstrLabel);
					SendMessage(GetDlgItem(IDC_OUTPUTLIST),LB_ADDSTRING,0,(LPARAM)szItem);

					// 429 FIELDS
					COPILOT::IBT429FieldCollectionPtr p429Fields;
					pLabel->get_Field429s(&p429Fields);
					long lFieldCount;
					p429Fields->get_Count(&lFieldCount);
					for (long lFieldIndex=1; lFieldIndex<=lFieldCount; lFieldIndex++)
					{
						COPILOT::IBTPublic429FieldPtr p429Field;
						p429Fields->get_Item(CComVariant(lFieldIndex), &p429Field);
						CComBSTR bstrField;
						p429Field->get_Description(&bstrField);
						_stprintf(szItem,_T("    -- %ls"),bstrField);
						SendMessage(GetDlgItem(IDC_OUTPUTLIST),LB_ADDSTRING,0,(LPARAM)szItem);
					}// 429 FIELDS

				}// LABELS

			}// 429 CHANNELS

			// 708 CHANNELS
			COPILOT::IBT708ChanCollectionPtr p708Chans;
			
			//Assumes Core 0 only
			pCard->get_Chan708s(iCoreNum,&p708Chans);
			
			lChanCount = 0;
			if (p708Chans) p708Chans->get_Count(&lChanCount);
			for (long lChanIndex=1; lChanIndex<=lChanCount; lChanIndex++)
			{
				COPILOT::IBTPublic708ChanPtr p708Chan;
				p708Chans->get_Item(lChanIndex, &p708Chan);
				CComBSTR bstrChan;
				p708Chan->get_Description(&bstrChan);
				_stprintf(szItem,_T("-- %ls"),bstrChan);
				SendMessage(GetDlgItem(IDC_OUTPUTLIST),LB_ADDSTRING,0,(LPARAM)szItem);
			}// 708 CHANNELS

			// AFDX NETWORK
			COPILOT::IBT664NetworkCollectionPtr pAFDXChans;
			pCard->get_AFDXNets(&pAFDXChans);
			if (pAFDXChans)
			{
				pAFDXChans->get_Count(&lChanCount);
				for (long lChanIndex=1; lChanIndex<=lChanCount; lChanIndex++)
				{
					COPILOT::IBTPublic664NetworkPtr pAFDXChan;
					pAFDXChans->get_Item(lChanIndex, &pAFDXChan);
					CComBSTR bstrChan;
					pAFDXChan->get_Description(&bstrChan);
					_stprintf(szItem,_T("-- %ls"),bstrChan);
					SendMessage(GetDlgItem(IDC_OUTPUTLIST),LB_ADDSTRING,0,(LPARAM)szItem);
				}// AFDX NETWORK
			}

			// MONITORS
			COPILOT::IBTMonitorCollectionPtr pMonitors;
			pCard->get_Monitors(iCoreNum,&pMonitors);
			
			long lMonCount=0;
			if (pMonitors) pMonitors->get_Count(&lMonCount);
			for (long lMonIndex=1; lMonIndex<=lMonCount; lMonIndex++)
			{
				long lRecTotal=0;
				long lRecCount=0;
				COPILOT::IBTPublicCopilotMonitorPtr	pMonitor;
				pMonitors->get_Item(CComVariant(lMonIndex), &pMonitor);

				COPILOT::IBT1553RecCollectionPtr pMon1553Recs;
				pMonitor->Record1553s(0, &pMon1553Recs);// Only gets records for channel 0
				pMon1553Recs->get_Count(&lRecCount);
				lRecTotal+=lRecCount;

				COPILOT::IBT429RecCollectionPtr pMon429Recs;
				pMonitor->get_Record429s(&pMon429Recs);
				pMon429Recs->get_Count(&lRecCount);
				lRecTotal+=lRecCount;

				COPILOT::IBT708RecCollectionPtr pMon708Recs;
				pMonitor->get_Record708s(0, &pMon708Recs);// Only gets records for channel 0
				pMon708Recs->get_Count(&lRecCount);
				lRecTotal+=lRecCount;

				COPILOT::IBTAFDXRecCollectionPtr pMonAFDXRecs;
				pMonitor->get_RecordAFDXs(&pMonAFDXRecs);// Only gets records for channel 0
				pMonAFDXRecs->get_Count(&lRecCount);
				lRecTotal+=lRecCount;

				CComBSTR bstrMon;
				pMonitor->get_Description(&bstrMon);
				_stprintf(szItem,_T("-- %ls (%d)"),bstrMon,lRecTotal);
				SendMessage(GetDlgItem(IDC_OUTPUTLIST),LB_ADDSTRING,0,(LPARAM)szItem);

			}// MONITORS

		}// CARD

		// Update status text
		VARIANT_BOOL bRunning=VARIANT_FALSE;
		_pCopilot->get_Running(&bRunning);
		if (bRunning)
		{
			ULONG ulRunTime=0;
			_pCopilot->get_RunTime(&ulRunTime);

			TCHAR szStatus[_MAX_PATH];
			_stprintf(szStatus,_T("%ls - Running %u"),_bstrProjName,(ulRunTime/1000));
			SetDlgItemText(IDC_TEXTSTATUS,szStatus);
		}
	}

public:
	// ******* Create a Smart Pointer to the Application ********
	// Smart-pointers encapsulate interface pointers and eliminate the need to call AddRef, 
	// Release, QueryInterface functions. In addition, it hides the CoCreateInstance call 
	// in creating a new COM object.
	// NOTE: The Destructor for IBTPublicCopilotShellPtr will automatically release the 
	// interface pointer when _pCopilot goes out of scope.
	COPILOT::IBTPublicCopilotShellPtr _pCopilot;

	CComBSTR _bstrProjName;

};

/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_MAINDLG_H__48CC6312_2882_4CA5_ADEF_49863B653C6A__INCLUDED_)

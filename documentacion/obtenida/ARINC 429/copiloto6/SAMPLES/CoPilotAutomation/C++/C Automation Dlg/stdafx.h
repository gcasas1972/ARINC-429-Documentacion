// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__D8EB0E2C_676C_4B0F_B7DF_88BA736EC526__INCLUDED_)
#define AFX_STDAFX_H__D8EB0E2C_676C_4B0F_B7DF_88BA736EC526__INCLUDED_

// Change these values to use different versions
#define WINVER		0x0400
//#define _WIN32_WINNT	0x0400
#define _WIN32_IE	0x0400
#define _RICHEDIT_VER	0x0100

#include <atlbase.h>
#include <atlapp.h>

extern CAppModule _Module;

#include <atlwin.h>
#include <stdio.h>

//**************** Import the Type Library ****************
// The content of the type library is converted into C++ classes, mostly describing
// the COM interfaces. The path points to your copy of the CoPilot application.
// The rename_namespace attribute is used to rename the namespace that contains the 
// contents of the type library. The raw_interfaces_only attribute expose only the 
// low-level contents of the type library. The named_guids attribute tells the compiler 
// to define and initialize GUID variables in old style, of the form LIBID_MyLib, 
// CLSID_MyCoClass, IID_MyInterface, and DIID_MyDispInterface.

#import "C:\Program Files\Ballard\CoPilot5\CoPilot.exe" rename_namespace("COPILOT") raw_interfaces_only named_guids

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__D8EB0E2C_676C_4B0F_B7DF_88BA736EC526__INCLUDED_)

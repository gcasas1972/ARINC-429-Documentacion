package com.ballardtech.examples.console;

import java.awt.BorderLayout;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.PipedInputStream;
import java.io.PipedOutputStream;
import java.io.PrintStream;

import javax.swing.*;
import javax.swing.text.Document;

public class ExamplesGUI extends JFrame implements KeyListener
{
	private static final long serialVersionUID = 8260156970984234386L;
	final static int PROT_1553 = 0;
	final static int PROT_429 = 1;

    public ExamplesGUI() 
    {
        initUI();
    }

	private void cleanUp() 
	{
		//Clean up example thread
		_example.cleanup();
	}
	
	private void displayHelp()
	{
		HelpDialog dlg = new HelpDialog();
	    if (_radio1553.isSelected()) dlg._resource = "/res/readme1553.txt";
        else dlg._resource = "/res/readme429.txt";
		dlg.initUI(this);
		dlg.setVisible(true);
	}
	
    public final void initUI() 
    {
       JPanel panel = new JPanel();
       getContentPane().add(panel);
       
       panel.setLayout(null);

       //Frame initialization
       setTitle("Console Examples");
       setSize(600, 400);
       setLocationRelativeTo(null);
       setDefaultCloseOperation(EXIT_ON_CLOSE);
       
       //Prompt
       JLabel textPrompt = new JLabel("Select a protocol and example:");
       textPrompt.setBounds(5, 0, 200, 30);
       panel.add(textPrompt);
       
       //Radio 1553
       _radio1553 = new JRadioButton("1553");
       _radio1553.setBounds(0, 30, 60, 30);
       _radio1553.setMnemonic(KeyEvent.VK_1);
       _radio1553.addActionListener(new ActionListener() {
           public void actionPerformed(ActionEvent event) {
        	   PopulateDropdown(PROT_1553);
          }
       });
       _radio1553.setSelected(true);
       panel.add(_radio1553);

       //Radio 429
       _radio429 = new JRadioButton("429");
       _radio429.setBounds(60, 30, 60, 30);
       _radio429.setMnemonic(KeyEvent.VK_4);
       _radio429.addActionListener(new ActionListener() {
           public void actionPerformed(ActionEvent event) {
        	   PopulateDropdown(PROT_429);
          }
       });
       panel.add(_radio429);
       
       //Radio Group
       ButtonGroup group = new ButtonGroup();
       group.add(_radio1553);
       group.add(_radio429);
       
       //Combobox
       _dropdownSelExamp = new JComboBox<String>(_example1553strings);
       _dropdownSelExamp.setBounds(120, 30, 120, 30);
       _dropdownSelExamp.setSelectedIndex(0);
       panel.add(_dropdownSelExamp);
       
       //Run Button
       JButton runButton = new JButton("Run");
       runButton.setBounds(250, 30, 80, 30);
       runButton.addActionListener(new ActionListener() {
           public void actionPerformed(ActionEvent event) {
        	   RunSelectedExample();
          }
       });
       panel.add(runButton);
       
       //Help Button
       JButton helpButton = new JButton("Help");
       helpButton.setBounds(410, 30, 80, 30);
       helpButton.addActionListener(new ActionListener() {
           public void actionPerformed(ActionEvent event) {
	   			displayHelp();
          }
       });
       panel.add(helpButton);
       
       //Exit Button
       JButton exitButton = new JButton("Exit");
       exitButton.setBounds(500, 30, 80, 30);
       exitButton.addActionListener(new ActionListener() {
           public void actionPerformed(ActionEvent event) {
	   			if (_example.isRunning())
	   			{
	   				JOptionPane.showMessageDialog(null, "You must exit the current example to quit.", "Error", JOptionPane.ERROR_MESSAGE);
	   				return;
	   			}
	   			cleanUp();
	   			System.exit(0);
          }
       });
       panel.add(exitButton);
       
       //Scrolling Text (holds Console)
       JTextArea textComponent = new JTextArea();
       textComponent.addKeyListener(this);
       JScrollPane scrollPane = new JScrollPane(textComponent);
       scrollPane.setBounds(15, 75, 555, 275);
       panel.add(scrollPane, BorderLayout.CENTER);
       _console = new Console(textComponent);
       _console.redirectOut();
    }
    
    /** Handle the key typed event from the text field. */
    public void keyTyped(KeyEvent e) 
    {
    }

    /** Handle the key-pressed event from the text field. */
    public void keyPressed(KeyEvent e) 
    {
    	if (!_example.isRunning()) return;
    	
    	try {
    		_pout.write(e.getKeyCode());
    	}
    	catch (Exception exception) {
    		exception.printStackTrace();
    	}
    }

    /** Handle the key-released event from the text field. */
    public void keyReleased(KeyEvent e) 
    {
    }
    
	private class Console extends JTextArea
    {
		private static final long serialVersionUID = 6306245873373469817L;
		public Console(JTextArea text)
    	{
    		this._text = text;
    		this._document = text.getDocument();
    		_text.setEditable(false);
    		_text.setFont(new Font(Font.MONOSPACED,Font.PLAIN,12));
    	}

    	/*
    	 *  Redirect the output from the standard output to the console.
    	 */
    	public void redirectOut()
    	{
    		ConsoleOutputStream cos = new ConsoleOutputStream();
    		System.setOut( new PrintStream(cos, true) );
    	}
		
    	/*
    	 *	Class to intercept output from a PrintStream and add it to a Document.
    	 */
    	class ConsoleOutputStream extends ByteArrayOutputStream
    	{
    		public void flush()
    		{
    			String message = toString();

    			if (message.length() == 0) return;

    			handleAppend(message);

    			reset();
    		}

    		private void handleAppend(String input)
    		{
            	//Handle the '\r' as a carriage return with no line-feed
            	//i.e. reuse last line, the text is replaced whereever
            	//_cursorindex is found, which is typically at the end of the text
            	//unless '\r' is encountered
	        	if (input.contains("\r"))
	        	{
	        		int start = 0;
	        		int index = input.indexOf("\r", start);
	        		if (index > start) 
	    			{
	            		String sub = input.substring(start, index);
	            		appendAtCursor(sub);
	    			}
	        		start = index + 1;
	            	_cursorindex = getFirstIndexLastLine();
	        		
	        		do
	        		{
	            		index = input.indexOf("\r", start);
	            		if (index >= 0)
	            		{
	            			String sub = input.substring(start, index);
	            			appendAtCursor(sub);
	            		}
	            		else
	            		{
	            			String sub = input.substring(start);
	            			appendAtCursor(sub);
	            			break;
	            		}
	            		
	            		start = index + 1;
	                	_cursorindex = getFirstIndexLastLine();
	        		} while (index >= 0);
	        		
	        	}
	        	else
	        		appendAtCursor(input);
    		}
    	}

		//Appends the input string at the current input position
		//Replacing characters that are in place already and appending those
		//Past the end of the text
        private void appendAtCursor(String str)
        {
        	int lastLineRemaining = _text.getText().length() - _cursorindex;
        	if (lastLineRemaining < 1)
        	{
        		appendString(str);
        		return;
        	}
        	
        	int strLen = str.length();
        	
        	int replaceLen = (strLen < lastLineRemaining) ? strLen : lastLineRemaining;
        	
        	if (replaceLen > 0)
    		{
        		_text.replaceRange(str, _cursorindex, _cursorindex + replaceLen);
    		}
        	if (strLen > replaceLen) appendString(str.substring(replaceLen-1));
        	
    		_cursorindex = _cursorindex + replaceLen;
        }		 
        
        //Appends the string to the end of the text 
        private void appendString(String input)
        {
            _text.append(input);
			_text.setCaretPosition(_document.getLength());
            
            _cursorindex = _text.getText().length();
        }
        
        //This returns the first index in the last line of the text
        private int getFirstIndexLastLine()
        {
        	int firstIndexLastLine = _text.getText().toString().lastIndexOf("\n");
        	firstIndexLastLine++;
        	return firstIndexLastLine;
        }    	
		
    	public JTextArea _text;
    	private Document _document;
		private int _cursorindex;
    }
    
	protected void RunSelectedExample() 
	{
 	   if (_example.isRunning())
 	   {
 		   JOptionPane.showMessageDialog(null, "An example is already running.", "Error", JOptionPane.ERROR_MESSAGE);
 		   return;
 	   }
 	   
 	   //Set focus to console to accept key presses
 	   _console._text.requestFocusInWindow();
 	   
       int protocol = PROT_1553;
	   if (_radio1553.isSelected()) protocol = PROT_1553;
       else if (_radio429.isSelected()) protocol = PROT_429;   
 	   String exampName = (String) _dropdownSelExamp.getSelectedItem();
 	   _example.RunExample(protocol, exampName);
	}

	private void PopulateDropdown(int protocol) 
    {
		_dropdownSelExamp.removeAllItems();
		
		String[] populateList;
        switch (protocol)
        {
        case PROT_1553: populateList = _example1553strings; break;
        case PROT_429: populateList = _example429strings; break;
        default: populateList = new String[] {"Error"};
        }
     
        for (int i = 0; i < populateList.length; i++)
        	_dropdownSelExamp.addItem(populateList[i]);
	}
	
    //This is the example thread which runs the example code
    private class ExampleInstance implements Runnable 
    {
        public ExampleInstance() 
        {
        }

        public void cleanup()
        {
    		synchronized (this) {
    			notifyAll();
    		}

    		try {_examplethread.join(1000);_pin.close();_pout.close();} catch (Exception ex){}        	
        }
		
        //The method that actually executes the example and starts the thread running
        public boolean RunExample(int protocol, String example) 
        {
        	if (isRunning()) return false;
        	
        	_protocol = protocol;
        	_example = example;

        	_pin = new PipedInputStream(10000);
        	
            try {
            	_pout = new PipedOutputStream(_pin);
            }
        	catch (Exception e) {
        	    e.printStackTrace();
        	}
        	
        	_examplethread = new Thread(this);
        	_examplethread.start();
            
        	return true;
        }
        
        public synchronized void run() 
        {
           switch (_protocol)
           {
           case PROT_1553: Examples1553.RunExample(_example, _pin, System.out); break;
           case PROT_429: Examples429.RunExample(_example, _pin, System.out); break;
           }
           
           try {
				_pin.close();
				_pout.close();
		   } catch (IOException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
		   }
        }
        
        public boolean isRunning()
        {
        	return ((_examplethread != null) && _examplethread.isAlive());
        }

		private Thread _examplethread = null;
        private int _protocol;
        private String _example;
        private PipedInputStream _pin;
    }
    
    public static void main(String[] args) 
    {
        SwingUtilities.invokeLater(new Runnable() {
            public void run() {
            	ExamplesGUI ex = new ExamplesGUI();
                ex.setVisible(true);
            }
        });
    }

	PipedOutputStream _pout;
	private Console _console;
    JComboBox<String> _dropdownSelExamp;
	private JRadioButton _radio1553;
	private JRadioButton _radio429;
	private ExampleInstance _example = new ExampleInstance();
    private String[] _example429strings = { "Example 1", "Example 2", "Example 3", "Example 4", "Example 5",
    										"Example 6", "Example 8", "Example 12", "Example 13", "Example 14", 
    										"Example 15", "Example 16", "Example 17"};
    private String[] _example1553strings = { "Example 1", "Example 2", "Example 3", "Example 4", "Example 5",
    		 								 "Example 7", "Example 8", "Example 10", "Example 12", "Example 15",
    		 								 "Example 16"};
}

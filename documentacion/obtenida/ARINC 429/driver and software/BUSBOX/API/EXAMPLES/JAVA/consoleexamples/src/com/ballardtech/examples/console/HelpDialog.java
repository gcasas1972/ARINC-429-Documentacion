package com.ballardtech.examples.console;

import java.awt.Font;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;

import javax.swing.JFrame;
import javax.swing.JScrollPane;
import javax.swing.JTextArea;

public class HelpDialog extends JFrame
{
	private static final long serialVersionUID = 1229671886826667825L;
	public String _resource;

    public HelpDialog() 
    {
    }

    public final void initUI(ExamplesGUI parent) 
    {
		//Frame initialization
		setTitle("Help");
		setSize(800, 600);
		setLocationRelativeTo(null);
		setDefaultCloseOperation(DISPOSE_ON_CLOSE);
	    
	    //Scrolling Text (holds help text)
	    JTextArea textComponent = new JTextArea();
	    JScrollPane scrollPane = new JScrollPane(textComponent);
		getContentPane().add(scrollPane);
		textComponent.setEditable(false);
		textComponent.setFont(new Font(Font.MONOSPACED,Font.PLAIN,12));
	    
		InputStream inputStream = parent.getClass().getResourceAsStream(_resource);
		if (inputStream == null) return;
		
		InputStreamReader inputreader = new InputStreamReader(inputStream);
		BufferedReader buffreader = new BufferedReader(inputreader);
		String line;
		StringBuilder text = new StringBuilder();
	
		try {
			while (( line = buffreader.readLine()) != null) 
			{
	          text.append(line);
	          text.append('\n');
	       }
	    } catch (IOException e) {
	    	return;
	    }
		
		textComponent.setText(text.toString());
		textComponent.setCaretPosition(0);
    }
}

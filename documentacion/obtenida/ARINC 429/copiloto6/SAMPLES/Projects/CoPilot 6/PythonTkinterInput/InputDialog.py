from Tkinter import *
instring = ""

class MyDialog:
    def __init__(self, parent,inputtext):

        top = self.top = Toplevel(parent)

        Label(top, text=inputtext).pack()

        self.e = Entry(top)
        self.e.pack(padx=5)

        b = Button(top, text="OK", command=self.ok)
        b.pack(pady=5)

    def ok(self):
        global instring
        instring = self.e.get()

        self.top.destroy()

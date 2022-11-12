import tkinter as tk
from login import Login
#########################################
Mainwindow = tk.Tk()
Mainwindow.title('Barbearia')

login = Login(Mainwindow)

Mainwindow.mainloop()
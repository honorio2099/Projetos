import sys
import tkinter as tk
from telinhapypet import TelinhaPypet
from pypet import Pypet
from tkinter import ttk

sys.setrecursionlimit(3000)
pypet = Pypet()

window = tk.Tk()
window.geometry('720x480')

telinhapypet = TelinhaPypet(window)

window.mainloop()
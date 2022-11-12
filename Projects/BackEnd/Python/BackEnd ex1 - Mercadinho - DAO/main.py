import tkinter as tk
from .tela import Tela

window = tk.Tk()
window.title('Produtos')
tela = Tela(window)
tela.SetList()

window.mainloop()
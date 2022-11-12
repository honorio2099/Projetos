import tkinter as tk
from tela import Tela

window = tk.Tk()
window.title('Viagem Legal')

tela = Tela(window)
tela.carregarComboDestino()

window.mainloop()
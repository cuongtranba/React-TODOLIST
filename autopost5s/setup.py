import os
from cx_Freeze import setup, Executable

base = None

os.environ['TCL_LIBRARY'] = "F:\\Python\\Python36-32\\tcl\\tcl8.6"
os.environ['TK_LIBRARY'] = "F:\\Python\\Python36-32\\tcl\\tk8.6"

executables = [Executable("autopost.py", base=base)]

packages = ["idna"]
options = {
    'build_exe': {
        'packages':packages,
    },

}

setup(
    name = "autopost",
    options = options,
    version = "1.0",
    description = 'make by bacuongtr@gmail.com',
    executables = executables
)

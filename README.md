See example image in files.

Package required: System.Drawing.Common


Its really simple.
Use function named "Convert".
Give it the image and its returns you the 'dotted line' version of the image.
Each lines are seprated with a '\n' in the returned string.

"Convert" arguments:
Image = it must be square.
Sections = the amount of the 'dots' per line.
Threshold = its a number between 0 and 100.
Threshold specifies which amount of brightness is required to put 'dot'.

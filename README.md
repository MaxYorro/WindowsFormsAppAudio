# WindowsFormsAppAudio
Windows Form Application that cuts apart an MP3 file based on copy/pasted timestamps as input.  The program will create a folder based
on the original mp3 file's name and store all the new mp3 files inside.

The program will "clean up" the names given to it.  For example, windows really doesn't like files to have /'s or :'s in them, 
so the program will remove those characters from the mp3 title.  I also decided to remove all numbers from the name of the mp3 file.


Input:
  The input must have a time in the form of:
  Number:Number NameOfTheSong \n
  
  It will take each line as a single song's data.
  

Dependencies:
  The program uses Naudio https://github.com/naudio/NAudio for cutting up the mp3 file and taglib http://taglib.org/ for adding 
  mp3 meta data like the song count.
  
  
Hopefully this will help more than it hurts,
Best!

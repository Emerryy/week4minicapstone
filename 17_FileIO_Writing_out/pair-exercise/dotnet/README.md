# File I/O Part 2 Exercises (Pair)

## FindAndReplace

Write a program that can be used to open a file and find and replace all occurrences of one word with another word.  

The program should prompt the user for the following values:

* The search phrase
* The replace phrase 
* The source file path.  *This must be an existing file.  If the user enters an invalid source file path, the program indicates this to the user and exits.*
* The destination file path.  *The program **creates a copy** of the source file with the requested replacements at this location.  If a file or directory already exists at this location, the program prints an error and exits.*

Use `alice.txt` for test input.
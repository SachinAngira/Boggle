# Boggle
Boggle Game Documentation
Implemented By : Sachin Angira.

Project Description:          
            A Boggle Problem solver implementation using Unity3D engine.
Rules to play boggle:   
As all kind of games have same rules, so does the boggle game so our boggle solver also have to follow those rules and they are as following:
•	The letters must be adjoining in a 'chain'. (Letter cubes in the chain may be adjacent horizontally, vertically, or diagonally.)
•	Words must contain at least three letters (But in our case we let the user decide to choose word Constraints).
•	No letter cube may be used more than once within a single word.
                                              
                                              
                                              
                                              
                                              
                                              

User input:   
                   The whole Boggle Solving Computation is Based upon user input only so we take various user inputs in various phase that are as:
                                                

                                                          (Phase 1)

1.	Add board dimensions:      
                              Here User adds his desired dimensions of the board.

2.	Add board character:
                              Here user adds characters in single line without using any                          white or blank space and that input will latter we converted into multidimensional character array. For Example:

     This  “ abcdedfhg “       will be converted into  this   “ a b c”  
                                                                                                   d e f
                                                                                                    f h g
Yes matrix’s dimensions will be according to user previous entered height and width.

3.	Add Constraints:  
                               Value provided by the user will be used as word constraint means any word below that size in the dictionary will be ignored.

                                               (Phase 2)

4.	Add dictionary size: 
                             Value inserted in this text field will be used as the number of words for our dictionary.

5.	Add your dictionary separated by space:  
                               Here user will add his dictionary words and every word should be separated by a space.

Solution:   
                       After taking all the user inputs algorithm starts by firstly converting input character string into multidimensional array of characters.
And the dictionary words that are stored as string are converted into array of string. Then all the letters from theses both are converted into Uppercase to resolve any case sensitivity issue later on. Then a Depth First Search is performed starting from every cell. Below is the Execution time of the algorithm for pre added input values:
Compile:	2.594s
Execute:	0.016s
Memory:	0b
CPU:	1.547s
       




Assumptions:    
                           Firstly I broke problem into 3 parts:
•	Taking the user input.
•	Solving the boggle problem.
•	Displaying the result.
    
Input:  For the input first I thought of making a grid type GUI using that if user inserts the dimensions of board it seizes itself on runtime but as the dimensions could be very large displaying equivalent grid matrix could be a headache as the dimensions can be as large as they couldn’t be fit into the camera frame. Then I end up coming with the idea of taking all the inputs as text field and I was able to make my input system up and running in about half a day.

Solution:  well converting the user inputs into a commutable data structure through that I can performer DFS (Depth first search) using one into another was itself very tough after failing various (Way too various) times I was able to come up with a prototype working algorithm and it took me around day and half and then refining and added things one or two were continuously happing even today (3rd sep 2019).

Output:  output part was easiest of all and all I have to convert and loop through some array and strings and it was working totally fine and it also took me half day to come up with a up and running output model.


Challenges/ Issues:    
                           
Things that were resolved: 
                                 Well the biggest challenge was this boggle problem itself but even after coming up with working model I still faced various challenges most of them just UI bugs or Some legacy Exceptions that I didn’t even know existed I forgot to catch them all then after throwing various case scenarios onto the model and solved all of the issues I faced but if still some exists I apologies already. 

Things that still exists: 
                               The thing I still won’t be able to solve I think is this problem in unity3D that it sometimes loses focus out of the button and then have to click here and there and if after that button is pressed it works.
                                   And the major issue I wasn’t able to resolve is the calculation time for the Unity3D because if I use same code only using
IDE to run it and no gameObject or Anything in the Scene then the calculation time for a 4*4 matrix with more then 5-6 dictionary words it took
Compile:	2.594s
Execute:	0.016s
Memory:	0b
CPU:	1.547s
	
	
But if I run it on the game it is very time Consuming. Firstly I thought as I’m Taking the input and then converting the data in Unity may be that is taking more time so separated these processes so all the input and conversion processes could be carried out separately. Even after doing that it Still Wasn’t able to make it any fast in the unity3D.

Project links:
                  I really hope you are going for the project after reading 
The whole documentation.
           Build Ready Standalone Application: https://drive.google.com/open?id=1RA5msBkxeMm_f3OzL8BokAm_iKyDBreJ 
                       
           GitHub Repo Project Link:            https://github.com/SachinAngira/Boggle
                                                          

           GDrive Hosted Project Link:          https://drive.google.com/open?id=1Cw_5sKZ4eUmg6MzN7a6cltuCVcJeuSCh



It was really a great experience working on a project like this
For any further query or information you can connect to me at

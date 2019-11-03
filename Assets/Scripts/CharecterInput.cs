using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class CharecterInput : MonoBehaviour
{
   
  
  
    int Limit;
   
    
    public GameObject WaringObj;
    public GameObject Frame2;
    public GameObject Frame3;
    public GameObject Frame4;
    public GameObject Frame5;
    public GameObject warningForDictinarySize;
    public GameObject warningForDictinary;


    public Text print,CharectersInput,DictionaryInput;
    public Text WarningText, CharacterFiled, height, width, dictonarySizeText,dictionaryWords,ConstraintValue;
    protected bool GoToNextFrame = false;
  

    protected String S1 = "";
    protected String[] dictionary = {};
    protected String dictionaryString;
    protected string str2 = "";
    public char[,] boggle;
  //  int n;
    int dictonarySize;
    int N,M;
    int Constraint = 0;






    void Start()
    {
        
        WarningText.text = "! There shloud be only ";

        M = 0;
        N = 0;
       
       


        
        }




    //this function is going to be updated
   public void DictinoryRead()
    {
        try
        {
            dictonarySize = System.Convert.ToInt32(dictonarySizeText.text);
         //   Debug.Log(dictonarySize);
        }
        catch (Exception e)
        {
            warningForDictinarySize.SetActive(true);
        }
        if (dictionaryWords.text == "")
        {
            warningForDictinary.SetActive(true);
        }
        dictionaryString = dictionaryWords.text.ToString();
        dictionaryString = ToUpper(dictionaryString);



        dictionaryString += ' ';
        dictionary = dictionaryString.Split(' ');



        GoToNextFrame = true;


       try
        {
            for (int Y = 0; Y < dictonarySize; Y++)
            {
                if (Y % 4 == 0)
                {
                    DictionaryInput.text += "\n";
                }
                DictionaryInput.text += " " + dictionary[Y];
            }
        }
        catch {
            warningForDictinary.SetActive(true);
            GoToNextFrame = false;
        }
      


        for (int x = 0; x < M; x++)
        {
            CharectersInput.text += "\n";
            for (int j = 0; j < N; j++)
            {
               CharectersInput.text += " " + boggle[x, j];
              
            }
        }
        if (GoToNextFrame == true)
        {
            Frame4.SetActive(true);
            Frame3.SetActive(false);
        }
       
    }

   public void Find()
   {
    
       Frame5.SetActive(true);
       Frame4.SetActive(false);
       findWords(boggle);
     Print();
       


   }

    
    public void OnClick()
    {
        // Calculates boardDimentions from playerfrebs
        M = PlayerPrefs.GetInt("Height");
        N = PlayerPrefs.GetInt("Width");
        Limit = N * M;
        Debug.Log(Limit);
        Constraint = System.Convert.ToInt32(ConstraintValue.text); ;
     //   Debug.Log(Constraint + "c");

        if (CharacterFiled.text.Length != Limit) // If Board dimentions doesn't matches the number board charecters
        {
            WaringObj.SetActive(true);
             WarningText.text = "! There shloud be only " + Limit + " Charecters";
            

        }
        else if (CharacterFiled.text.Length == 0)
        {
            WarningText.text = "Board Can't be Empty";
            WaringObj.SetActive(true);
        }
        
        else // If Board dimentions matches the number board charecters
        {
           
            TextToChar(CharacterFiled); 
         
           
            
            Frame2.SetActive(false);
            Frame3.SetActive(true);
            warningForDictinary.SetActive(false);
           
        }
    }



    //Resets all the input Fields from Frame2
    public void OnRest()
    {

        CharacterFiled.text.Remove(0, CharacterFiled.text.Length);
        WaringObj.SetActive(false);
        height.text = "0";
        width.text = "0";
       

    }





    void TextToChar(Text CharecterFiled) // To convert the input String into multidimentional charecter array
      {
          String st = CharecterFiled.text;
        st = ToUpper(st);
        char[] charArray = st.ToCharArray(); ; //String to Single Dimentional charecter array





        boggle = new char[M, N];
        int Z = 0; //this is index to travers Single Dimentional charecter array


        //This loop converts single dimentional charecter Array into 
        //multidimentional charecter array

        for (int x = 0; x < M; x++)
        {

            for (int j = 0; j < N; j++)
            {
                boggle[x, j] = charArray[Z];
                Z++;
             //   Debug.Log(x + " " + j + boggle[x, j]);
            }
        }
    }





    // Searches for the word
    bool searchWord(String str)
    {
       
        for (int i = 0; i < dictonarySize; i++)
            if (str.Equals(dictionary[i]))
                return true;
        return false;
    }

    // A recursive function that finds all words that are present 
    void IswordIs(char[,] boggle, bool[,] visited,
                             int i, int j, String str)
    {
        // Mark current cell as visited and 
        // append current character to str 
        visited[i, j] = true;
        str = str + boggle[i, j];

        // If str is present in dictionary, 
        // then add to result string;
        if (searchWord(str))
        {
            Debug.Log(str);
            AddToString(str);
        }
       
           // AddToString(str);
          

        // Traverse 8 adjacent cells of boggle[i,j] 
        for (int row = i - 1; row <= i + 1 && row < M; row++)
            for (int col = j - 1; col <= j + 1 && col < N; col++)
                if (row >= 0 && col >= 0 && !visited[row, col])
                    IswordIs(boggle, visited, row, col, str);

        // Erase current character from string and  
        // mark visited of current cell as false 
        str = "" + str[str.Length - 1];
        visited[i, j] = false;
    }

    // Prints all words present in dictionary
    void findWords(char[,] boggle)
    {
        // Mark all characters as not visited 
        bool[,] visited = new bool[M, N];

        // Initialize current string 
        String str = "";
      
        // Consider every character and look for all words 
        // starting with this character 
        for (int i = 0; i < M; i++)
            for (int j = 0; j < N; j++)
                IswordIs(boggle, visited, i, j, str);
       
    }
    public void Print() // Prints the result
    {

        if (S1 == "")
        {
            S1 = "Nothing Matched !";
        }
        print.text = S1;
    }

    public void AddToString(string str)
    {

        

        for (int i = 0; i < dictonarySize; i++)
        {

            if (S1.Contains(str))
            {
                continue;
            }
            else
            {
                if (str.Length > Constraint)
                {
                    S1 += " " + str;
                }
            }
        }
        
        }
          
          
 
        
    

    //To set warning text appear when the Dictionary Size input field is empty
    public void OnListEmpty()
    {
        warningForDictinarySize.SetActive(false);
    }

  



    // Coverts the any String Tto uppre case
    String ToUpper(String text) 
    {
        text= text.ToUpper();
        return text;
    }

    public void OnTryAgain()
    {
        SceneManager.LoadScene(0);
    }
}





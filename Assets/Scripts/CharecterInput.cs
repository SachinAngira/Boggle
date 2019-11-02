using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CharecterInput : MonoBehaviour
{
    char[,] Charecters;
  
    public Text inputFiled;
    int Limit;
    public GameObject textfield;
    public InputField Cahrecter;
    public Text textField, CharecterFiled, height, width;
    public GameObject Frame2;
    public GameObject Frame4;
    public Text print;


    public String[] dictionary = { "LOB", "TUX", "SEA", "FAM" };

    public char[,] boggle;
    int n = 4;
    int N,M;






    void Start()
    {

        textField.text = "! There shloud be only ";

        M = PlayerPrefs.GetInt("Height");
        N = PlayerPrefs.GetInt("Width");



        Console.WriteLine("Following words of " +
                          "dictionary are present");
       



    }
    //this function is going to be updated
   public void DictinoryRead()
    {
        findWords(boggle);
    }
    


    
    public void OnClick()
    {
        
        Limit = N * M;
        Debug.Log(Limit);
        if (CharecterFiled.text.Length > Limit || CharecterFiled.text.Length < Limit) // If Board dimentions doesn't matches the number board charecters
        {
            textfield.SetActive(true);
            textField.text += Limit + " Charecters";
            Frame4.gameObject.SetActive(true);

        }
        else                        // If Board dimentions matches the number board charecters
        {
            
            TextToChar(CharecterFiled); 
         
           
            
            Frame2.SetActive(false);
            Frame4.SetActive(true);
           
        }
    }
    //Resets all the input Fields from Frame2
    public void OnRest()
    {

        CharecterFiled.text.Remove(0, CharecterFiled.text.Length);
        textfield.SetActive(false);
        height.text = "0";
        width.text = "0";
        textField.text = "! There shloud be only ";

    }
    void TextToChar(Text CharecterFiled) // To convert the input String into multidimentional charecter array
      {
        char[] charArray = CharecterFiled.text.ToCharArray(); ; //String to Single Dimentional charecter array





        boggle = new char[N, M];
        int Z = 0; //this is index to travers Single Dimentional charecter array


        //This loop converts single dimentional charecter Array into 
        //multidimentional charecter array

        for (int x = 0; x < N; x++)
        {

            for (int j = 0; j < M; j++)
            {
                boggle[x, j] = charArray[Z];
                Z++;
                Debug.Log(x + " " + j + boggle[x, j]);
            }
        }
    }

       



    
    bool searchWord(String str)
    {
        // Searches for the word
        for (int i = 0; i < n; i++)
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
        // then print it 
        if (searchWord(str))
            Print(str);
          

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
    public void Print(string str) // Prints the result
    {
        print.text += " " +str.ToString();
    }

}
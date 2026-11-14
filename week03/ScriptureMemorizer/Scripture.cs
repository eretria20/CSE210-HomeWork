using System;
using System.Collections.Generic;

public class Scripture
{
    private  Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();
    
    // Constructor to initialize Scripture with a reference and text
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[]splitWords = text.Split(' ');
        foreach (string wordText in splitWords)
        {
            _words.Add(new Word(wordText));
        }
    }

// Method to hide a specified number of random words
    public void HideRandomWords(int numberToHide)
    {
        List<Word> visibleWords = new List<Word>();
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                visibleWords.Add(word);
            }
        }

        int count = Math.Min(numberToHide, visibleWords.Count);
        for (int i = 0; i < count; i++)
        {
            int index = _random.Next(visibleWords.Count);
            visibleWords[index].Hide(); 
            visibleWords.RemoveAt(index);
        }
    }

    public void RevealRandomWord()
    {
        List<Word> hiddenWords = new List<Word>();
        foreach (Word word in _words)
        {
            if (word.IsHidden())
            {
                hiddenWords.Add(word);
            }
        }

        if (hiddenWords.Count > 0)
        {
            int index = _random.Next(hiddenWords.Count);
            hiddenWords[index].Show();
        }
    }

// Method to get the display text for the scripture, including the reference and words
    public string GetDisplayText()
    {
      List<string> displayWords = new List<string>();
      foreach (Word word in _words)
        {
            displayWords.Add(word.GetDisplayText());
        }
        return $"{_reference.GetDisplayText()} {string.Join(" ", displayWords)}";
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}
using System;
using System.Collections.Generic;

public class Resume
{
   // variable for the person's name
   public string _name;

   // variable for the list of Jobs
   public List<Job> _jobs = new List<Job>();

// method to display the resume
   public void Display()
   {
      Console.WriteLine($"Name: {_name}");
      Console.WriteLine("Jobs:");
      // loop through each job in the list and call its Display method
      foreach (Job job in _jobs)
      {
         job.Display();
      }
   }

}
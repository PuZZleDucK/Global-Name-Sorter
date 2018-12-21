﻿using System;
using Models;
using System.Collections.Generic;

namespace NameSorter
{
    public class NameSorter
    {
      private List<Person> inputNames;
      private List<Person> sortedNames;

      public NameSorter() {
        inputNames = new List<Person>();
      }

      public void addPerson(Person newPerson) {
        inputNames.Add(newPerson);
      }

      public List<Person> sortPeople() {
        sortedNames = inputNames;
        return sortedNames;
      }
    }
}

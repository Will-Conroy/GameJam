using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandProcessor 
{
   private List<Command> _commands = new List<Command>();
   private int _currentComandIndex = -1;

   public void ExecuteCommand(Command command){
       //_commands.Add(command);
       command.Execute();
       //_currentComandIndex = _commands.Count -1;
   }

   public void AddCommand(Command command){
        _commands.Add(command);
   }

   public void ExecuteNext(){
       Command command = _commands[0];
       _commands.RemoveAt(0);
       command?.Execute();
       //_currentComandIndex = _commands.Count -1;
   }

   public void RunAllCommands(){
       while(_commands.Count != 0)
             ExecuteNext();
    }
   
}

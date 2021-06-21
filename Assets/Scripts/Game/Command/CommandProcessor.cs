using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CommandProcessor 
{
    /*-----Events-----*/
    public UnityEvent<string> commandExcutionStart = new UnityEvent<string>();
    public UnityEvent<string> commandExcuted = new UnityEvent<string>();
    /*-----Veriables-----*/
   private Queue<Command> _commands = new Queue<Command>();
   private int _currentComandIndex = -1;
   private bool excuting;

   public void ExecuteCommand(Command command){
       //_commands.Add(command);
       commandExcutionStart?.Invoke(command.getInfo());
       command?.Execute();
       commandExcuted?.Invoke(command.getInfo());
       //_currentComandIndex = _commands.Count -1;
   }

   public void AddCommand(Command command){
        _commands.Enqueue(command);
   }

   public void ExecuteNext(){
       ExecuteCommand(_commands.Dequeue());
       //_currentComandIndex = _commands.Count -1;
   }

   public void RunAllCommands(){
       while(_commands.Count != 0){
           if(!excuting)
            ExecuteNext();
       }
             
    }
   
}

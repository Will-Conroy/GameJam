using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CommandProcessor
{
    /*-----Events-----*/
    public UnityEvent<string> commandExcutionStart = new UnityEvent<string>();
    //public UnityEvent<string> commandExcuted = new UnityEvent<string>();
    /*-----Veriables-----*/
   private Queue<Command> _commands = new Queue<Command>();
   private int _currentComandIndex = -1;
   private bool excuting;
   public CommandProcessor(){
       excuting = false;
   }

   public void ExecuteCommand(Command command){
       //_commands.Add(command);
       if(!excuting){
           setExcuting(true);
            commandExcutionStart?.Invoke(command.getInfo());
            command?.Excuted.AddListener(finishCommandSingle);
            command?.Execute();
       }

       
       //commandExcuted?.Invoke(command.getInfo());
       //_currentComandIndex = _commands.Count -1;
   }

   private void setExcuting(bool isExcuitng){
       excuting = isExcuitng;
   }

   private void toggalExcuting(){
       excuting = !excuting;
   }

   public void AddCommand(Command command){
        _commands.Enqueue(command);
   }

   public void ExecuteNext(){
        ExecuteCommandWithOutCheck(_commands.Dequeue());
       //_currentComandIndex = _commands.Count -1;
   }

   private void ExecuteCommandWithOutCheck(Command command){
        setExcuting(true);
        commandExcutionStart?.Invoke(command.getInfo());
        command?.Excuted.AddListener(finishCommandContinuous);
        command?.Execute();
   }

   public void RunAllCommands(){
        if(_commands.Count > 0 && !excuting){
            ExecuteNext();
        }else{
            Debug.Log("Will is the smellest");
        }
            

    }
    private void finishCommandSingle(Command command){
         command.Excuted.RemoveListener(finishCommandSingle);
         setExcuting(false);
         Debug.Log("Pat smells");
    }

    private void finishCommandContinuous(Command command){
         command.Excuted.RemoveListener(finishCommandContinuous);
         setExcuting(false);
         if(_commands.Count >0)
            ExecuteNext();
         Debug.Log("Pat smells a Lot");
    }
   
}

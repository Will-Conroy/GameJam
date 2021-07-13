using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CommandProcessor
{
    /*---- Events ----*/
    public UnityEvent<string> commandExcutionStart = new UnityEvent<string>();


    /*-----Veriables-----*/
   private Queue<Command> _commands = new Queue<Command>();
   private bool excuting;


    /*---- Initialization ----*/
    public CommandProcessor(){
        excuting = false;
    }
    

    /*---- Methods ----*/
   public void ExecuteCommand(Command command){
       if(!excuting){
           setExcuting(true);
            invokeCommandExuctionStart(command.getInfo());
            command?.Excuted.AddListener(finishCommandSingle);
            command?.Execute();
       }
   }


   protected virtual void invokeCommandExuctionStart(string commandInfo){
       commandExcutionStart?.Invoke(commandInfo);
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
        }
    }
    private void finishCommandSingle(Command command){
         command.Excuted.RemoveListener(finishCommandSingle);
         setExcuting(false);
    }

    private void finishCommandContinuous(Command command){
         command.Excuted.RemoveListener(finishCommandContinuous);
         setExcuting(false);
         if(_commands.Count >0)
            ExecuteNext();
    }
   
}

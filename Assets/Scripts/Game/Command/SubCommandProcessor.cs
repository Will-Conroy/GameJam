using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCommandProcessor : CommandProcessor
{
    private CommandProcessor _parentCommandProcessor;

    public SubCommandProcessor(CommandProcessor parentCommandProcessor){
        _parentCommandProcessor = parentCommandProcessor;
    }

    protected override void invokeCommandExuctionStart(string commandInfo){
       _parentCommandProcessor.commandExcutionStart?.Invoke(commandInfo);
   }


}

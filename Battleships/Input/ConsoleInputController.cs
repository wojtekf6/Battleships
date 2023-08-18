using System;
using System.Text.RegularExpressions;
using Battleships.Config;
using Battleships.Exceptions.Input;
using Battleships.Utils;

namespace Battleships.Input
{
    public class ConsoleInputController : IInputController
    {
        private readonly GameConfig _config;
        
        public ConsoleInputController(GameConfig config)
        {
            _config = config;
        }
        
        public InputData GetUserInput()
        {
            InputData inputData = null;
            
            try
            {
                var userInput = Console.ReadLine();
                inputData = ParseUserInput(userInput);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return inputData;
        }
        
        private InputData ParseUserInput(string userInput)
        {
            if (!Regex.IsMatch(userInput, InputUtils.GetInputPattern(_config.BoardSize))
                || !InputUtils.ValidateMaxSize(userInput, _config.BoardSize))
            {
                throw new InvalidInputException();
            }

            var column = userInput[0].GetColumnIndex();
            var row = int.Parse(userInput[1].ToString()) - 1;

            return new InputData { Row = row, Column = column };
        }
    }
}
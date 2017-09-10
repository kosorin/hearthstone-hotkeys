﻿using HearthstoneHotkeys.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HearthstoneHotkeys.Actions
{
    public class Click : IAction
    {
        public string Name { get; }

        public GamePoint Position { get; }

        public MouseButton Button { get; }

        public Click(string name, GamePoint position, MouseButton button = MouseButton.Left)
        {
            Name = name;
            Position = position;
            Button = button;
        }

        public async Task ExecuteAsync()
        {
            var oldPosition = Mouse.GetCursorPosition();
            var position = Window.GamePositionToScreenPosition(Position);

            Mouse.SetCursorPosition(position);
            Mouse.Click(Button);

            await Task.Delay(Input.Delay);
            Mouse.SetCursorPosition(oldPosition);
        }
    }
}

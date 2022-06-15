using System;
using System.Collections.Generic;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Example.Scrolling
{
    public class UpdateStatusAction : Byui.Games.Scripting.Action
    {
        public UpdateStatusAction()
        {
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                Actor player = scene.GetFirstActor("player");
                Label status = scene.GetFirstActor<Label>("status");
                status.Display($"x:{player.GetPosition().X}, y:{player.GetPosition().Y}");
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't update status.", exception);
            }
        }
    }
}
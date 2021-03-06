﻿namespace TagCloud
{
    public interface IAction
    {
        string CommandName { get; }
        string Description { get; }
        void Perform(ClientConfig config);
    }
}
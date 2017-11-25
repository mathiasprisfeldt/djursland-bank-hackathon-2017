using AcrylecSkeleton.Utilities;
using UnityEngine;

namespace QuestBoard
{
    public enum BoardState { World, Board, Note }

    /// <summary>
    /// Purpose:
    /// Creator:
    /// </summary>
    public class QuestBoardHandler : Singleton<QuestBoardHandler>
    {
        public BoardState State { get; set; }

        public void SetState(BoardState state)
        {
            State = state;
            //Zoom to right state;
        }
    }
}
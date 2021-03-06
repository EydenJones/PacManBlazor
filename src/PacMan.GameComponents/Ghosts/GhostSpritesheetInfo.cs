﻿using System.Collections.Generic;
using System.Numerics;

namespace PacMan.GameComponents.Ghosts
{
    public class GhostSpritesheetInfo
    {
        const int _width = 16;

        readonly Dictionary<Directions, FramePair> _frames;

        public GhostSpritesheetInfo(Vector2 position)
        {
            _frames = new Dictionary<Directions, FramePair>();

            var toMove = new Vector2(_width, 0);

            Vector2 marker = position;

            _frames[Directions.Right] = new FramePair(position, position + toMove);
            marker = marker + toMove;
            marker = marker + toMove;

            _frames[Directions.Left] = new FramePair(marker, marker + toMove);
            marker = marker + toMove;
            marker = marker + toMove;

            _frames[Directions.Up] = new FramePair(marker, marker + toMove);
            marker = marker + toMove;
            marker = marker + toMove;

            _frames[Directions.Down] = new FramePair(marker, marker + toMove);
        }

        public Vector2 GetSourcePosition(Directions direction, bool useFirstFrame)
        {
            FramePair frame = _frames[direction];

            return useFirstFrame ? frame.First : frame.Second;
        }
    }
}
﻿namespace ThunderFighter
{
    using System;
    using System.Collections.Generic;

    class KillerWingEnemy : Enemy, IShooter
    {
        private static List<Pixel> EnemyBody(Point2D pos)
        {
            List<Pixel> body = new List<Pixel>();

            body.Add(new Pixel(0, 0, '<', ConsoleColor.Blue));
            body.Add(new Pixel(1, -1, '=', ConsoleColor.Blue));
            body.Add(new Pixel(1, 1, '=', ConsoleColor.Blue));
            body.Add(new Pixel(2, 0, ':', ConsoleColor.Blue));
            body.Add(new Pixel(2, -2, '/', ConsoleColor.DarkBlue));
            body.Add(new Pixel(2, 2, '\\', ConsoleColor.DarkBlue));

            body.Add(new Pixel(3, 0, '=', ConsoleColor.Blue));
            body.Add(new Pixel(4, 0, '=', ConsoleColor.Blue));
            body.Add(new Pixel(5, 0, '=', ConsoleColor.Blue));
            body.Add(new Pixel(6, 0, '=', ConsoleColor.Blue));
            body.Add(new Pixel(7, 0, '=', ConsoleColor.Blue));
            body.Add(new Pixel(8, 0, '=', ConsoleColor.Blue));
            body.Add(new Pixel(9, 0, '=', ConsoleColor.Blue));
            body.Add(new Pixel(10, 0, '=', ConsoleColor.Blue));
            return body;
        }
        public KillerWingEnemy(Field field, Point2D position) : this(field, position, EnemyBody(position))
        {
        }
        public KillerWingEnemy(Field field, Point2D position, List<Pixel> body) : base(field, position, body)
        {
        }

        public override void Move()
        {
            this.Position.X--;

            this.ReCalculateBody();
        }

        public void Shoot()
        {
            throw new NotImplementedException();
        }
    }
}
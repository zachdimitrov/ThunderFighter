﻿namespace ThunderFighter.Enemies
{
    using System;
    using System.Collections.Generic;
    using ThunderFighter.Bullets;

    internal class BadShooterEnemy : Enemy, IBulletShooter
    {
        // random position where BadShooter enemy stops movement on X axis
        private int randomPositionToStopMovementOnXAxis;

        public BadShooterEnemy(Field field, Point2D position) :
            this(field, position, EntityState.Strong)
        {
        }

        public BadShooterEnemy(Field field, Point2D position, EntityState entityState) :
            this(field, position, BadShooterEnemy.BodyStates(), entityState)
        {
        }

        public BadShooterEnemy(Field field, Point2D position, List<List<Pixel>> bodyStates, EntityState entityState) :
            base(field, position, bodyStates, entityState)
        {
            // you can override here initial bomb movement direction values set in base constructor
            this.DeltaX = -1;
            this.DeltaY = -0.75M;

            this.randomPositionToStopMovementOnXAxis = RandomProvider.Instance.Next(this.Field.Width / 4, this.Field.Width - (this.Field.Width / 4));
        }

        public override void Move()
        {
            if (this.Position.X <= this.randomPositionToStopMovementOnXAxis)
            {
                this.DeltaX = 0;
            }

            if (this.Position.Y < 0)
            {
                this.DeltaY = 0.6M;
            }

            if (this.Position.Y > this.Field.Height - 10)
            {
                this.DeltaY = -0.6M;
            }

            this.EnemyPositionX += this.DeltaX;
            this.EnemyPositionY += this.DeltaY;

            this.Position.X = (int)this.EnemyPositionX;
            this.Position.Y = (int)this.EnemyPositionY;

            // shooting frequency - should depend on level
            int bulletEngage = RandomProvider.Instance.Next(0, 21);
            if (bulletEngage < Constants.EasyEnemyBulletsMaxCount)
            {
                this.BulletShoot();
            }
        }

        public override void BulletShoot()
        {
            var bullet = new LightEnemyBullet(this.Field, new Point2D(this.Position));

            // redefines bullet speed and direction
            bullet.DeltaX = -3;
            bullet.DeltaY = 0;

            this.Bullets.Add(bullet);
        }

        private static List<List<Pixel>> BodyStates()
        {
            List<List<Pixel>> bodyStates = new List<List<Pixel>>();

            List<Pixel> strongBody = new List<Pixel>();
            strongBody.Add(new Pixel(0, 0, ':', ConsoleColor.Black));
            strongBody.Add(new Pixel(1, -1, '<', ConsoleColor.DarkGreen));
            strongBody.Add(new Pixel(2, -1, '|', ConsoleColor.DarkGreen));
            strongBody.Add(new Pixel(2, 1, '|', ConsoleColor.DarkGreen));
            strongBody.Add(new Pixel(1, 1, '<', ConsoleColor.DarkGreen));
            strongBody.Add(new Pixel(1, 0, 'X', ConsoleColor.Black));
            strongBody.Add(new Pixel(2, 0, 'X', ConsoleColor.Black));
            strongBody.Add(new Pixel(3, 0, ':', ConsoleColor.Green));

            List<Pixel> halfDestroyedBody = new List<Pixel>();
            halfDestroyedBody.Add(new Pixel(0, 0, '*', ConsoleColor.DarkMagenta));
            halfDestroyedBody.Add(new Pixel(-1, 1, '*', ConsoleColor.DarkMagenta));
            halfDestroyedBody.Add(new Pixel(0, 1, '*', ConsoleColor.DarkMagenta));
            halfDestroyedBody.Add(new Pixel(1, 1, '*', ConsoleColor.DarkMagenta));
            halfDestroyedBody.Add(new Pixel(0, 2, '*', ConsoleColor.DarkMagenta));

            List<Pixel> destroyedBody = new List<Pixel>();
            destroyedBody.Add(new Pixel(0, -1, '+', ConsoleColor.DarkYellow));
            destroyedBody.Add(new Pixel(2, -1, '+', ConsoleColor.DarkYellow));
            destroyedBody.Add(new Pixel(-1, 1, '+', ConsoleColor.DarkYellow));
            destroyedBody.Add(new Pixel(2, 0, '+', ConsoleColor.DarkYellow));
            destroyedBody.Add(new Pixel(1, -2, '+', ConsoleColor.DarkYellow));
            destroyedBody.Add(new Pixel(2, 2, '+', ConsoleColor.DarkYellow));

            bodyStates.Add(strongBody);        // EntityState.Strong
            bodyStates.Add(halfDestroyedBody); // EntityState.HalfDestroyed
            bodyStates.Add(destroyedBody);     // EntityState.Destroyed

            return bodyStates;
        }
    }
}

﻿namespace ThunderFighter
{
    using System.Collections.Generic;

    internal abstract class Enemy : Entity, IMovable, IBulletShooter
    {
        private decimal deltaX;
        private decimal deltaY;

        private decimal enemyPositionX;
        private decimal enemyPositionY;

        private List<Bullet> bullets;
        private List<Missile> missiles;

        protected Enemy(Field field, Point2D position, List<List<Pixel>> bodyStates, EntityState entityState) :
            base(field, position, bodyStates, entityState)
        {
            // defines initial enemy movement direction values
            this.DeltaX = -1.0M;
            this.DeltaY = 0M;

            this.EnemyPositionX = position.X;
            this.EnemyPositionY = position.Y;

            this.bullets = new List<Bullet>();
            this.missiles = new List<Missile>();
        }

        public decimal DeltaX
        {
            get
            {
                return this.deltaX;
            }

            set
            {
                this.deltaX = value;
            }
        }

        public decimal DeltaY
        {
            get
            {
                return this.deltaY;
            }

            set
            {
                this.deltaY = value;
            }
        }

        internal List<Bullet> Bullets
        {
            get
            {
                return this.bullets;
            }

            set
            {
                this.bullets = value;
            }
        }

        internal List<Missile> Missiles
        {
            get
            {
                return this.missiles;
            }

            set
            {
                this.missiles = value;
            }
        }

        protected decimal EnemyPositionX
        {
            get
            {
                return this.enemyPositionX;
            }

            set
            {
                this.enemyPositionX = value;
            }
        }

        protected decimal EnemyPositionY
        {
            get
            {
                return this.enemyPositionY;
            }

            set
            {
                this.enemyPositionY = value;
            }
        }

        public virtual void Move()
        {
            this.EnemyPositionX += this.DeltaX;
            this.EnemyPositionY += this.DeltaY;

            this.Position.X = (int)this.EnemyPositionX;
            this.Position.Y = (int)this.EnemyPositionY;

            // fly in a safe distance above buildings
            if (this.Position.Y > this.Field.Height - 10)
            {
                this.Position.Y = this.Field.Height - 10;
            }
        }

        public abstract void BulletShoot();
    }
}

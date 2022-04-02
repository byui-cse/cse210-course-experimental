using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using Byui.Games.Casting;
using Byui.Games.Services;
using Raylib_cs;


namespace Byui.Games.Services
{
    public class RaylibPhysicsService : IPhysicsService
    {
        public RaylibPhysicsService() { }

        public void BounceIn(Rectangle region, Circle circle)
        {
            if (circle.GetLeft() < region.GetLeft() || circle.GetRight() > region.GetRight())
            {
                Vector2 oldVelocity = circle.GetVelocity();
                Vector2 newVelocity = new Vector2(oldVelocity.X * -1, oldVelocity.Y);
                circle.SetVelocity(newVelocity);
            }
            else if (circle.GetTop() < region.GetTop() || circle.GetBottom() > region.GetBottom())
            {
                Vector2 oldVelocity = circle.GetVelocity();
                Vector2 newVelocity = new Vector2(oldVelocity.X, oldVelocity.Y * -1);
                circle.SetVelocity(newVelocity);
            }
        }

        public void BounceIn(Rectangle region, Polygon polygon)
        {
            if (polygon.GetLeft() < region.GetLeft() || polygon.GetRight() > region.GetRight())
            {
                Vector2 oldVelocity = rectangle.GetVelocity();
                Vector2 newVelocity = new Vector2(oldVelocity.X * -1, oldVelocity.Y);
                polygon.SetVelocity(newVelocity);
            }
            else if (polygon.GetTop() < region.GetTop() || polygon.GetBottom() > region.GetBottom())
            {
                Vector2 oldVelocity = texture.GetVelocity();
                Vector2 newVelocity = new Vector2(oldVelocity.X, oldVelocity.Y * -1);
                polygon.SetVelocity(newVelocity);
            }
        }

        public void BounceIn(Rectangle region, Rectangle rectangle)
        {
            if (rectangle.GetLeft() < region.GetLeft() || rectangle.GetRight() > region.GetRight())
            {
                Vector2 oldVelocity = rectangle.GetVelocity();
                Vector2 newVelocity = new Vector2(oldVelocity.X * -1, oldVelocity.Y);
                rectangle.SetVelocity(newVelocity);
            }
            else if (rectangle.GetTop() < region.GetTop() || rectangle.GetBottom() > region.GetBottom())
            {
                Vector2 oldVelocity = texture.GetVelocity();
                Vector2 newVelocity = new Vector2(oldVelocity.X, oldVelocity.Y * -1);
                rectangle.SetVelocity(newVelocity);
            }
        }

        public void BounceIn(Rectangle region, Texture texture)
        {
            if (texture.GetLeft() < region.GetLeft() || texture.GetRight() > region.GetRight())
            {
                Vector2 oldVelocity = texture.GetVelocity();
                Vector2 newVelocity = new Vector2(oldVelocity.X * -1, oldVelocity.Y);
                texture.SetVelocity(newVelocity);
            }
            else if (texture.GetTop() < region.GetTop() || texture.GetBottom() > region.GetBottom())
            {
                Vector2 oldVelocity = texture.GetVelocity();
                Vector2 newVelocity = new Vector2(oldVelocity.X, oldVelocity.Y * -1);
                texture.SetVelocity(newVelocity);
            }
        }

        public bool IsAbove(Casting.Rectangle subject, Casting.Rectangle agent)
        {
            Raylib_cs.Rectangle rec1 = ToRaylibRectangle(subject);
            Raylib_cs.Rectangle rec2 = ToRaylibRectangle(agent);
            Raylib_cs.Rectangle intersection = Raylib.GetCollisionRec(rec1, rec2);
            return IsAbove(rec1, intersection);
        }

        public bool IsAbove(Texture subject, Texture agent)
        {
            Raylib_cs.Rectangle rec1 = ToRaylibRectangle(subject);
            Raylib_cs.Rectangle rec2 = ToRaylibRectangle(agent);
            Raylib_cs.Rectangle intersection = Raylib.GetCollisionRec(rec1, rec2);
            return IsAbove(rec1, intersection);
        }

        public bool IsBelow(Casting.Rectangle subject, Casting.Rectangle agent)
        {
            Raylib_cs.Rectangle rec1 = ToRaylibRectangle(subject);
            Raylib_cs.Rectangle rec2 = ToRaylibRectangle(agent);
            Raylib_cs.Rectangle intersection = Raylib.GetCollisionRec(rec1, rec2);
            return IsBelow(rec1, intersection);
        }

        public bool IsBelow(Texture subject, Texture agent)
        {
            Raylib_cs.Rectangle rec1 = ToRaylibRectangle(subject);
            Raylib_cs.Rectangle rec2 = ToRaylibRectangle(agent);
            Raylib_cs.Rectangle intersection = Raylib.GetCollisionRec(rec1, rec2);
            return IsBelow(rec1, intersection);
        }

        public bool IsInside(Vector2 point, Circle circle)
        {
            Vector2 center = circle.GetPosition();
            float radius = circle.GetRadius();
            return Raylib.CheckCollisionPointCircle(point, center, radius);
        }

        public bool IsInside(Vector2 point, Casting.Rectangle rectangle)
        {
            Raylib_cs.Rectangle rec = ToRaylibRectangle(rectangle);
            return Raylib.CheckCollisionPointRec(point, rec);
        }

        public bool IsInside(Vector2 point, Texture texture)
        {
            Raylib_cs.Rectangle rec = ToRaylibRectangle(texture);
            return Raylib.CheckCollisionPointRec(point, rec);
        }

        public bool IsLeft(Casting.Rectangle subject, Casting.Rectangle agent)
        {
            Raylib_cs.Rectangle rec1 = ToRaylibRectangle(subject);
            Raylib_cs.Rectangle rec2 = ToRaylibRectangle(agent);
            Raylib_cs.Rectangle intersection = Raylib.GetCollisionRec(rec1, rec2);
            return IsLeft(rec1, intersection);
        }

        public bool IsLeft(Texture subject, Texture agent)
        {
            Raylib_cs.Rectangle rec1 = ToRaylibRectangle(subject);
            Raylib_cs.Rectangle rec2 = ToRaylibRectangle(agent);
            Raylib_cs.Rectangle intersection = Raylib.GetCollisionRec(rec1, rec2);
            return IsLeft(rec1, intersection);
        }

        public bool IsOverlapping(Circle subject, Circle agent)
        {
            Vector2 center1 = subject.GetPosition();
            float radius1 = subject.GetRadius();
            Vector2 center2 = agent.GetPosition();
            float radius2 = agent.GetRadius();
            return Raylib.CheckCollisionCircles(center1, radius1, center2, radius2);
        }

        public bool IsOverlapping(Circle subject, Casting.Rectangle agent)
        {
            Vector2 center = subject.GetPosition();
            float radius = subject.GetRadius();
            Raylib_cs.Rectangle rec = ToRaylibRectangle(agent);
            return Raylib.CheckCollisionCircleRec(center, radius, rec);
        }

        public bool IsOverlapping(Casting.Rectangle subject, Casting.Rectangle agent)
        {
            Raylib_cs.Rectangle rec1 = ToRaylibRectangle(subject);
            Raylib_cs.Rectangle rec2 = ToRaylibRectangle(agent);
            return Raylib.CheckCollisionRecs(rec1, rec2);
        }

        public bool IsOverlapping(Texture subject, Circle agent)
        {
            Vector2 center = agent.GetPosition();
            float radius = agent.GetRadius();
            Raylib_cs.Rectangle rec = ToRaylibRectangle(subject);
            return Raylib.CheckCollisionCircleRec(center, radius, rec);
        }

        public bool IsOverlapping(Texture subject, Casting.Rectangle agent)
        {
            Raylib_cs.Rectangle rec1 = ToRaylibRectangle(subject);
            Raylib_cs.Rectangle rec2 = ToRaylibRectangle(agent);
            return Raylib.CheckCollisionRecs(rec1, rec2);
        }

        public bool IsOverlapping(Texture subject, Texture agent)
        {
            Raylib_cs.Rectangle rec1 = ToRaylibRectangle(subject);
            Raylib_cs.Rectangle rec2 = ToRaylibRectangle(agent);
            return Raylib.CheckCollisionRecs(rec1, rec2);
        }

        public bool IsRight(Casting.Rectangle subject, Casting.Rectangle agent)
        {
            Raylib_cs.Rectangle rec1 = ToRaylibRectangle(subject);
            Raylib_cs.Rectangle rec2 = ToRaylibRectangle(agent);
            Raylib_cs.Rectangle intersection = Raylib.GetCollisionRec(rec1, rec2);
            return IsRight(rec1, intersection);
        }

        public bool IsRight(Texture subject, Texture agent)
        {
            Raylib_cs.Rectangle rec1 = ToRaylibRectangle(subject);
            Raylib_cs.Rectangle rec2 = ToRaylibRectangle(agent);
            Raylib_cs.Rectangle intersection = Raylib.GetCollisionRec(rec1, rec2);
            return IsRight(rec1, intersection);
        }

        public void LimitTo(Rectangle region, Circle circle)
        {
            int x = circle.GetLeft();
            int y = circle.GetTop();

            int maxX = region.GetRight() - circle.GetDiameter();
            int maxY = region.GetBottom() - circle.GetDiameter();
            int minX = region.GetX();
            int minY = region.GetY();

            x = Math.Clamp(x, minX, maxX);
            y = Math.Clamp(y, minY, maxY);

            Vector2 newPosition = new Vector2(x, y);
            circle.SetPosition(newPosition);
        }

        public void LimitTo(Rectangle region, Polygon polygon)
        {
            int x = polygon.GetLeft();
            int y = polygon.GetTop();

            int maxX = region.GetRight() - polygon.GetWidth();
            int maxY = region.GetBottom() - polygon.GetHeight();
            int minX = region.GetX();
            int minY = region.GetY();

            x = Math.Clamp(x, minX, maxX);
            y = Math.Clamp(y, minY, maxY);

            Vector2 newPosition = new Vector2(x, y);
            polygon.SetPosition(newPosition);
        }

        public void LimitTo(Rectangle region, Rectangle rectangle)
        {
            int x = rectangle.GetLeft();
            int y = rectangle.GetTop();

            int maxX = region.GetRight() - rectangle.GetWidth();
            int maxY = region.GetBottom() - rectangle.GetHeight();
            int minX = region.GetX();
            int minY = region.GetY();

            x = Math.Clamp(x, minX, maxX);
            y = Math.Clamp(y, minY, maxY);

            Vector2 newPosition = new Vector2(x, y);
            rectangle.SetPosition(newPosition);
        }

        public void LimitTo(Rectangle region, Texture texture)
        {
            int x = texture.GetLeft();
            int y = texture.GetTop();

            int maxX = region.GetRight() - texture.GetWidth();
            int maxY = region.GetBottom() - texture.GetHeight();
            int minX = region.GetX();
            int minY = region.GetY();

            x = Math.Clamp(x, minX, maxX);
            y = Math.Clamp(y, minY, maxY);

            Vector2 newPosition = new Vector2(x, y);
            texture.SetPosition(newPosition);
        }

        public void MoveNext(Shape shape, float deltaTime)
        {
            Vector2 position = shape.GetPosition();
            Vector2 velocity = shape.GetVelocity();
            position = position + velocity * deltaTime;
            shape.SetPosition(position);
        }

        public void MoveNext(Shape shape, float deltaTime, float gravity)
        {
            Vector2 position = shape.GetPosition();
            Vector2 velocity = shape.GetVelocity();
            velocity = velocity + new Vector2(0, gravity);
            position = position + velocity * deltaTime;
            shape.SetPosition(position);
        }

        public void MoveNext(Texture texture, float deltaTime)
        {
            Vector2 position = texture.GetPosition();
            Vector2 velocity = texture.GetVelocity();
            position = position + velocity * deltaTime;
            texture.SetPosition(position);
        }

        public void MoveNext(Texture texture, float deltaTime, float gravity)
        {
            Vector2 position = texture.GetPosition();
            Vector2 velocity = texture.GetVelocity();
            velocity = velocity + new Vector2(0, gravity);
            position = position + velocity * deltaTime;
            texture.SetPosition(position);
        }

        public void WrapIn(Rectangle region, Circle circle)
        {
            int x = circle.GetLeft();
            int y = circle.GetTop();

            int maxX = region.GetRight();
            int maxY = region.GetBottom();
            int minX = region.GetX() - circle.GetDiameter();
            int minY = region.GetY() - circle.GetDiameter();

            if (x < minX) x = maxX;
            if (x > maxX) x = minX;
            if (y < minY) y = maxY;
            if (y < maxY) x = minY;
            
            Vector2 newPosition = new Vector2(x, y);
            circle.SetPosition(newPosition);
        }

        public void WrapIn(Rectangle region, Polygon polygon)
        {
            int x = polygon.GetLeft();
            int y = polygon.GetTop();

            int maxX = region.GetRight();
            int maxY = region.GetBottom();
            int minX = region.GetX() - polygon.GetDiameter();
            int minY = region.GetY() - polygon.GetDiameter();

            if (x < minX) x = maxX;
            if (x > maxX) x = minX;
            if (y < minY) y = maxY;
            if (y < maxY) x = minY;

            Vector2 newPosition = new Vector2(x, y);
            polygon.SetPosition(newPosition);
        }

        public void WrapIn(Rectangle region, Rectangle rectangle)
        {
            int x = rectangle.GetLeft();
            int y = rectangle.GetTop();

            int maxX = region.GetRight();
            int maxY = region.GetBottom();
            int minX = region.GetX() - rectangle.GetWidth();
            int minY = region.GetY() - rectangle.GetHeight();

            if (x < minX) x = maxX;
            if (x > maxX) x = minX;
            if (y < minY) y = maxY;
            if (y < maxY) x = minY;

            Vector2 newPosition = new Vector2(x, y);
            rectangle.SetPosition(newPosition);
        }

        public void WrapIn(Rectangle region, Texture texture)
        {
            int x = texture.GetLeft();
            int y = texture.GetTop();

            int maxX = region.GetRight();
            int maxY = region.GetBottom();
            int minX = region.GetX() - texture.GetWidth();
            int minY = region.GetY() - texture.GetHeight();

            if (x < minX) x = maxX;
            if (x > maxX) x = minX;
            if (y < minY) y = maxY;
            if (y < maxY) x = minY;

            Vector2 newPosition = new Vector2(x, y);
            texture.SetPosition(newPosition);
        }

        private bool IsAbove(Raylib_cs.Rectangle subject, Raylib_cs.Rectangle intersection)
        {
            return (subject.y + subject.height == intersection.y + intersection.height
                && intersection.width > intersection.height);
        }

        private bool IsBelow(Raylib_cs.Rectangle subject, Raylib_cs.Rectangle intersection)
        {
            return (subject.y == intersection.y && intersection.width > intersection.height);
        }

        private bool IsLeft(Raylib_cs.Rectangle subject, Raylib_cs.Rectangle intersection)
        {
            return (subject.x + subject.width == intersection.x + intersection.width
                && intersection.height > intersection.width);
        }

        private bool IsRight(Raylib_cs.Rectangle subject, Raylib_cs.Rectangle intersection)
        {
            return (subject.x == intersection.x && intersection.height > intersection.width);
        }

        private Raylib_cs.Rectangle ToRaylibRectangle(Casting.Rectangle rectangle)
        {
            Vector2 position = rectangle.GetPosition();
            Vector2 size = rectangle.GetSize();
            return new Raylib_cs.Rectangle(position.X, position.Y, size.X, size.Y);
        }

        private Raylib_cs.Rectangle ToRaylibRectangle(Texture texture)
        {
            Vector2 position = texture.GetPosition();
            Vector2 size = texture.GetSize();
            return new Raylib_cs.Rectangle(position.X, position.Y, size.X, size.Y);
        }
    }
}

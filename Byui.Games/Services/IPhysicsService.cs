using System;
using System.Numerics;
using Byui.Games.Casting;


namespace Byui.Games.Services
{
    public interface IPhysicsService
    {
        void BounceIn(Rectangle region, Circle circle);
        void BounceIn(Rectangle region, Polygon polygon);
        void BounceIn(Rectangle region, Rectangle rectangle);
        void BounceIn(Rectangle region, Texture texture);
        bool IsAbove(Rectangle subject, Rectangle agent);
        bool IsAbove(Texture subject, Texture agent);
        bool IsBelow(Rectangle subject, Rectangle agent);
        bool IsBelow(Texture subject, Texture agent);
        bool IsInside(Vector2 point, Circle circle);
        bool IsInside(Vector2 point, Rectangle rectangle);
        bool IsInside(Vector2 point, Texture texture);
        bool IsLeft(Rectangle subject, Rectangle agent);
        bool IsLeft(Texture subject, Texture agent);
        bool IsOverlapping(Circle subject, Circle agent);
        bool IsOverlapping(Circle subject, Rectangle agent);
        bool IsOverlapping(Rectangle subject, Rectangle agent);
        bool IsOverlapping(Texture subject, Circle agent);
        bool IsOverlapping(Texture subject, Rectangle agent);
        bool IsOverlapping(Texture subject, Texture agent);
        bool IsRight(Rectangle subject, Rectangle agent);
        bool IsRight(Texture subject, Texture agent);
        void LimitTo(Rectangle region, Circle circle);
        void LimitTo(Rectangle region, Polygon polygon);
        void LimitTo(Rectangle region, Rectangle rectangle);
        void LimitTo(Rectangle region, Texture texture);
        void MoveNext(Shape shape, float deltaTime);
        void MoveNext(Shape shape, float deltaTime, float gravity);
        void MoveNext(Texture texture, float deltaTime);
        void MoveNext(Texture texture, float deltaTime, float gravity);
        void WrapIn(Rectangle region, Circle circle);
        void WrapIn(Rectangle region, Polygon polygon);
        void WrapIn(Rectangle region, Rectangle rectangle);
        void WrapIn(Rectangle region, Texture texture);
    }
}
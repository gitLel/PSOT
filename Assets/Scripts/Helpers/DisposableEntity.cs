using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class DisposableEntity : IDisposable
{
    private readonly CompositeDisposable _disposables = new();
    public void Dispose()
    {
        _disposables.Dispose();
    }

    ~DisposableEntity()
    {
        Dispose();
    }
    public void AddDisposable(IDisposable item)
    {
        _disposables.Add(item);
    }
}
public static class DisposableExtensions
{
    public static T AddTo<T>(this T disposable, DisposableEntity entity)
        where T : IDisposable
    {
        entity.AddDisposable(disposable);
        return disposable;
    }
}

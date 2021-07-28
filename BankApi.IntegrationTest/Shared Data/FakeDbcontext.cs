using System;
using Microsoft.EntityFrameworkCore;
using FakeItEasy;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using SharedData;

namespace BankApi.IntegrationTest.SharedData
{
    public static class FakeDbcontext
    {
        public static T Fake<T>() where T : DbContext
        {
            return A.Fake<T>(x => x.WithArgumentsForConstructor(new[] { new DbContextOptions<T>() }));
        }
        public static void MockData<TContext, TEntity>(this TContext context, List<TEntity> data, Expression<Func<DbSet<TEntity>>> expression) where TContext : DbContext where TEntity : class
        {
            IQueryable<TEntity> fakeIQueryable = data.AsQueryable();
            var fakeDbSet = A.Fake<DbSet<TEntity>>((d => d.Implements(typeof(IQueryable<TEntity>)).Implements<IAsyncEnumerable<TEntity>>()));
            //A.CallTo(() => ((IAsyncEnumerable<TEntity>)fakeDbSet).GetAsyncEnumerator(CancellationToken.None)).Returns(new TestAsyncEnumerator<TEntity>(fakeIQueryable.GetEnumerator()));
            // A.CallTo(() => ((IQueryable<TEntity>)fakeDbSet).Provider).Returns(new TestAsyncQueryProvider<TEntity>(fakeIQueryable.Provider));
            A.CallTo(() => ((IQueryable<TEntity>)fakeDbSet).GetEnumerator()).Returns(fakeIQueryable.GetEnumerator());
            A.CallTo(() => ((IQueryable<TEntity>)fakeDbSet).Provider).Returns( fakeIQueryable.Provider);
            A.CallTo(() => ((IQueryable<TEntity>)fakeDbSet).Expression).Returns(fakeIQueryable.Expression);
            A.CallTo(() => ((IQueryable<TEntity>)fakeDbSet).ElementType).Returns(fakeIQueryable.ElementType);
            A.CallTo(() => ((IQueryable<TEntity>)fakeDbSet).GetEnumerator()).Returns(fakeIQueryable.GetEnumerator());
            A.CallTo(expression).Returns(fakeDbSet);
            A.CallTo(() => fakeDbSet.Add(A<TEntity>._)).Invokes(x => data.Add(x.Arguments[0] as TEntity));
        }
    }
}

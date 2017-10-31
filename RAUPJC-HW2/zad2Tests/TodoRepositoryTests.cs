using Microsoft.VisualStudio.TestTools.UnitTesting;
using zad2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2.Tests
{
    [TestClass()]
    public class TodoRepositoryTests
    {
        [TestMethod()]
        public void TodoRepositoryTest()
        {
            TodoRepository t = new TodoRepository();
            Assert.IsNull(t.GetAll());
        }

        [TestMethod()]
        public void TodoRepositoryTest2()
        {
            GenericList<TodoItem> l = new GenericList<TodoItem>(5);
            for (int i = 0; i < 5; i++)
            {
                l.Add(new TodoItem((i+1) + "."));
            }
            TodoRepository t = new TodoRepository(l);
            for(int i = 0; i<5; i++)
            {
                Assert.AreEqual(t.Get(l.GetElement(i).Id), l.GetElement(i));
            }
        }

        [TestMethod()]
        public void AddTest()
        {
            TodoRepository t = new TodoRepository();
            TodoItem td = new TodoItem("prvi");
            Assert.AreEqual(t.Add(td), td);
        }

        [TestMethod()]
        public void GetTest()
        {
            TodoRepository t = new TodoRepository();
            TodoItem td = new TodoItem("prvi");
            Assert.AreEqual(t.Get(td.Id), td);
        }

        [TestMethod()]
        public void GetActiveTest()
        {
            GenericList<TodoItem> l = new GenericList<TodoItem>(5);
            for (int i = 0; i < 5; i++)
            {
                l.Add(new TodoItem((i + 1) + "."));
            }
            TodoRepository t = new TodoRepository(l);

            t.MarkAsCompleted(l.GetElement(0).Id);
            Assert.AreEqual(t.GetActive().Count, 4);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            GenericList<TodoItem> l = new GenericList<TodoItem>(5);
            for (int i = 0; i < 5; i++)
            {
                l.Add(new TodoItem("" + (i + 1)));
            }
            TodoRepository t = new TodoRepository(l);
            List<TodoItem> l2 = t.GetAll();
            int sum = 0;
            foreach(TodoItem temp in l2)
            {
                sum += int.Parse(temp.Text);
            }
            Assert.AreEqual(sum, 15);
        }

        [TestMethod()]
        public void GetCompletedTest()
        {
            GenericList<TodoItem> l = new GenericList<TodoItem>(5);
            for (int i = 0; i < 5; i++)
            {
                l.Add(new TodoItem((i + 1) + "."));
            }
            TodoRepository t = new TodoRepository(l);

            t.MarkAsCompleted(l.GetElement(0).Id);
            Assert.AreEqual(t.GetCompleted().Count, 1);
        }

        [TestMethod()]
        public void GetFilteredTest()
        {
            TodoRepository t = new TodoRepository();
        }

        [TestMethod()]
        public void MarkAsCompletedTest()
        {
            TodoRepository t = new TodoRepository();
            TodoItem td = new TodoItem("prvi");
            TodoItem td2 = new TodoItem("drugi");
            t.Add(td);
            t.Add(td2);
            Assert.AreEqual(t.MarkAsCompleted(td.Id), true);
            Assert.AreEqual(t.MarkAsCompleted(td.Id), false);
            Assert.AreEqual(t.MarkAsCompleted(new Guid()), false);


        }

        [TestMethod()]
        public void RemoveTest()
        {
            TodoRepository t = new TodoRepository();
            TodoItem td = new TodoItem("prvi");
            TodoItem td2 = new TodoItem("drugi");
            t.Add(td);
            t.Add(td2);
            Assert.AreEqual(t.Remove(td.Id), true);
            Assert.AreEqual(t.Remove(td.Id), false);
            Assert.AreEqual(t.Remove(new Guid()), false);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            TodoRepository t = new TodoRepository();
            TodoItem td = new TodoItem("prvi");
            t.Add(td);
            td.Text = "prvi2";
            t.Update(td);
            Assert.AreEqual(t.Get(td.Id).Text, "prvi2");
        }
    }
}
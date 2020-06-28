using System;
using System.Collections.Generic;

namespace Independency
{

    enum ItemStatus
    {
        Dependent,
        Independent,
        Run,
        Success,
        Fail
    }

    class DependentItem
    {
        public int Id { get; private set; }

        private ItemStatus status = ItemStatus.Independent;
        public ItemStatus Status
        {
            get { return status; }
            set
            {
                Console.WriteLine($"Item Status Changed ({Id.ToString()}):\t{status} => {value}");
                status = value;
            }
        }

        public HashSet<DependentItem> Parents { get; private set; } = new HashSet<DependentItem>();

        public HashSet<DependentItem> Childs { get; private set; } = new HashSet<DependentItem>();

        public DependentItem(int id)
        {
            Id = id;
        }

        public bool AddChild(DependentItem child)
        {
            if (Childs.Add(child))
            {
                if (child.AddParent(this))
                    return true;
                else
                    throw new Exception($"Failed to add Parent ({Id}) to child ({child.Id})...");

            }
            // Throw Exception here...
            throw new Exception($"Could not add Child {child.Id} to child list in {Id}...");
            //return false; 
        }


        public bool AddParent(DependentItem parent)
        {
            if (Parents.Add(parent))
            {
                Status = ItemStatus.Dependent;
                return true;
            }
            return false;
        }

        private bool RemoveParent(DependentItem parent)
        {
            if (Parents.Remove(parent))
            {
                // Status may change to Independet - 
                // when no more parents and previous state was dependent 
                if (Parents.Count == 0 && Status == ItemStatus.Dependent)
                    Status = ItemStatus.Independent;

                return true;
            }

            throw new Exception("Could not find parent here...");

            // return false;
        }

        public void SetSuccess()
        {
            // Informs It's childs
            foreach (var child in Childs)
            {
                child.RemoveParent(this);
            }

            // Change the state to Sucess
            if (Status != ItemStatus.Run)
            {
                // Might have a problems changing not running item
            }
            Status = ItemStatus.Success;
        }

        public void SetFail()
        {
            // Change the state to Fail
            Status = ItemStatus.Fail;

            // Informs It's childs - that they're fail now..
            foreach (var child in Childs)
            {
                child.SetFail();
            }
        }

        /// <summary>
        /// When checking for items status, an Independent Item's status is changed to RUN.
        /// </summary>
        /// <returns></returns>
        public bool IsIndependent()
        {
            if (Status == ItemStatus.Independent)
            {
                // Now is considered as Running
                Status = ItemStatus.Run;
                return true;
            }
            return false;
        }

    }
}

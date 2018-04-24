namespace MDL
{
    using System;

    public class OPCDataChangeMDL
    {
        private Array opcClientHandles;
        private Array opcItemValues;
        private int opcNumItems;

        public OPCDataChangeMDL(int numItems, Array clientHandles, Array itemValues)
        {
            this.opcNumItems = numItems;
            this.opcClientHandles = clientHandles;
            this.opcItemValues = itemValues;
        }

        public Array OpcClientHandles
        {
            get
            {
                return this.opcClientHandles;
            }
        }

        public Array OpcItemValues
        {
            get
            {
                return this.opcItemValues;
            }
        }

        public int OpcNumItems
        {
            get
            {
                return this.opcNumItems;
            }
        }
    }
}


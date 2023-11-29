using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace map_HW
{
    internal class map<K, V> : IEnumerable<KeyValuePair<K, V>>
    {
        private K[] key;
        private V[] value;
        private const int STARTSIZE = 5;
        private int size;
        private int index = 0;



        public map(K key, V value)
        {
            this.key = new K[STARTSIZE];
            this.value = new V[STARTSIZE];
            this.key[index] = key;
            this.value[index] = value;
            index++;
            size = STARTSIZE;
        }

        public void Add(K key, V value)
        {
            if (index == size)
            {
                IncrasheSizeArr();
            }
            if (FindKey(key))
            {
                this.key[index] = key;
                this.value[index] = value;
            }
            else
            {
                this.key[index] = key;
                this.value[index++] = value;
            }

        }

        private void IncrasheSizeArr()
        {
            K[] arrK = new K[size * 2];
            V[] arrV = new V[size * 2];
            for (int i = 0; i < key.Length; i++)
            {
                arrK[i] = key[i];
                arrV[i] = value[i];
            }
            key = arrK;
            value = arrV;
        }

        private bool FindKey(K key)
        {
            for (int i = 0; i < this.key.Length; i++)
            {
                if (this.key[i].Equals(key))
                {
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < size; i++)
            {
                sb.Append(key[i]);
                sb.Append(" ");
                sb.Append(value[i]);
                sb.Append('\n');
            }

            return sb.ToString();
            //return key.ToString() + value.ToString();
        }

        public V GetValueByKey(K key)
        {
            for(int i = 0; i < size; i++)
            {
                if (this.key[i].Equals(key))
                {
                    return value[i];
                }
            }
            throw new KeyNotFoundException("По вашему ключу ничего не найдено");
        }

        public K GetKeyByValue(V value)
        {
            for (int i = 0; i < size; i++)
            {
                if (this.value[i].Equals(value))
                {
                    return key[i];
                }
            }
            throw new Exception("По вашему значению ключ не найден");
        }

        public bool Remove(K key)
        {
            for(int i = 0; i < size; i++)
            {
                if (this.key[i].Equals(key))
                {
                    this.key[i] = default(K);
                    this.value[i] = default(V);
                    for(int j = i; j < size ; j++)
                    {
                        this.key[j] = this.key[j + 1];
                        this.value[j - 1] = this.value[j + 1];
                    }
                    this.key[size] = default(K);
                    this.value[size] = default (V);
                    return true;
                } 
            }
            return false;
        }

        //IEnumerable
        /* public IEnumerator<K> GetEnumerator()
         {
             for (int i = 0; i < index; i++)
             {
                 yield return key[i];
             }            
         }*/

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            for (int i = 0; i < index; i++)
            {
                yield return new KeyValuePair<K, V>(key[i], value[i]);
            }
        }



        IEnumerator IEnumerable.GetEnumerator()
        {
            return key.GetEnumerator();
        }

        //IEnumerator

    }
}

/*

Shemelin Pavel

2

Переписать программу, реализующее двоичное дерево поиска:
Добавить в него обход дерева различными способами.
Реализовать поиск в нём.
*Добавить в программу обработку командной строки с помощью которой можно указывать, из какого файла считывать данные, каким образом обходить дерево.

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        public class Node
        {
            int data;
            Node left;
            Node right;
            Node parent;

            public int Data
            {
                get
                { return this.data; }
                set
                { this.data = value; }
            }

            public Node Left
            {
                get
                { return this.left; }
                set
                { this.left = value; }
            }

            public Node Right
            {
                get
                { return this.right; }
                set
                { this.right = value; }
            }

            public Node Parent
            {
                get
                { return this.parent; }
                set
                { this.parent = value; }
            }

            public static void PrintTree( ref Node root )
            {
                if (root != null)
                {
                    Console.Write( root.Data );

                    if (root.left != null || root.right != null)
                    {
                        Console.Write( "(" );

                        if (root.left != null) PrintTree( ref root.left );
                        else Console.Write( "NULL" );

                        Console.Write( "," );

                        if (root.right != null) PrintTree( ref root.right );
                        else Console.Write( "NULL" );

                        Console.Write( ")" );
                    }
                }

            }

            public static Node GetFreeNode( int value, Node parent )
            {
                Node tmp = new Node { Data = value, Parent = parent };
                return tmp;
            }

            public static void Insert( ref Node head, int value )
            {
                Node tmp = null;
                if (head == null)
                {
                    head = GetFreeNode( value, null );
                    return;
                }
                tmp = head;
                while (tmp != null)
                {
                    if (value >= tmp.data)
                    {
                        if (tmp.right != null)
                        {
                            tmp = tmp.right;
                            continue;
                        }
                        else
                        {
                            tmp.right = GetFreeNode( value, tmp );
                            return;
                        }
                    }
                    else if (value < tmp.data)
                    {
                        if (tmp.left != null)
                        {
                            tmp = tmp.left;
                            continue;
                        }
                        else
                        {
                            tmp.left = GetFreeNode( value, tmp );
                            return;
                        }
                    }
                    else
                    {
                        throw new Exception( "Tree building fail" );
                    }
                }
            }

            public void PreOrderTravers( ref Node root )
            {
                if (root != null)
                {
                    Console.Write( root.data );
                    PreOrderTravers( ref root.left );
                    PreOrderTravers( ref root.right );
                }
            }
        }

        static void Main( string[] args )
        {
            Node tree = null;

            //эмуляция файла
            int[] file = new int[] { 8, 9, 12, 16, 6, 15, 6, 5, 12 };

            foreach (int item in file)
            {
                Node.Insert(ref tree, item);
            }

            Node.PrintTree( ref tree );

            Console.ReadKey();
        }
    }
}

/*

#include <stdio.h>
#include <malloc.h>
#include <stdlib.h>

typedef int T;
typedef struct Node {
    T data;
    struct Node *left;
    struct Node *right;
    struct Node *parent;
} Node;
// Распечатка двоичного дерева в виде скобочной записи
void printTree(Node *root) {
    if (root)
    {
        printf("%d",root->data);
        if (root->left || root->right)
        {
        printf("(");

        if (root->left) 
            printTree(root->left);
        else 
            printf("NULL");
        printf(",");

        if (root->right) 
            printTree(root->right);
        else 
            printf("NULL");
        printf(")");
        }
    }
}

// Создание нового узла
Node* getFreeNode(T value, Node *parent) {
    Node* tmp = (Node*) malloc(sizeof(Node));
    tmp->left = tmp->right = NULL;
    tmp->data = value;
    tmp->parent = parent;
    return tmp;
}

// Вставка узла
void insert(Node **head, int value) {
    Node *tmp = NULL;
    if (*head == NULL) 
    {
        *head = getFreeNode(value, NULL);
        return;
    }

    tmp = *head;
    while (tmp) 
    {
        if (value> tmp->data) 
        {
            if (tmp->right) 
            {
                tmp = tmp->right;
                continue;
            } 
            else 
            {
                tmp->right = getFreeNode(value, tmp);
                return;
            }
        } 
        else if (value< tmp->data) 
        {
            if (tmp->left) 
            {
                tmp = tmp->left;
                continue;
            } 
            else 
            {
                tmp->left = getFreeNode(value, tmp);
                return;
            }
        } 
        else 
        {
            exit(2);                     // Дерево построено неправильно
        }
    }
}

void preOrderTravers(Node* root) {
    if (root) {
        printf("%d ", root->data);
        preOrderTravers(root->left);
        preOrderTravers(root->right);
    }
}


int main()
{
    Node *Tree = NULL;
    FILE* file = fopen("data.txt", "r");
    if (file == NULL)
    {
        puts("Can't open file!");
        exit(1);
    }
    int count;
    fscanf(file, "%d", &count);          // Считываем количество записей
    int i;
    for(i = 0; i < count; i++)
    {
        int value;
        fscanf(file, "%d", &value);
        insert(&Tree, value);
    }
    fclose(file);
    printTree(Tree);
    printf("\nPreOrderTravers:");
    preOrderTravers(Tree);
    return 0;
}
*/

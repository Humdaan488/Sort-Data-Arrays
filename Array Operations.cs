#nullable enable

using System;
using static System.Console;

namespace Bme121
{
    static class Program
    {
        // Field 'rGen' and methods NewRandomArray and WriteArrayOneLine are used to
        // generate and display arrays used to test searching and sorting algorithms.

        static Random rGen = new Random( );

        // Create an integer array filled with random values.

        static int[ ] NewRandomArray( int size ) { return NewRandomArray( size, size ); }

        static int[ ] NewRandomArray( int size, int range )
        {
            if( size < 1 ) return new int[ 0 ];

            int[ ] result = new int[ size ];

            for( int i = 0; i < result.Length; i ++ )
            {
                result[ i ] = rGen.Next( 0, range );
            }

            return result;
        }

        // Write up to 10 elements of an integer array, all on one line.
        // The name to display for the index is passed as a string.
        // The name to display for the array is passed as a string.

        static void WriteArrayOneLine( int[ ] a ) { WriteArrayOneLine( a, "i", nameof( a ), true ); }
        static void WriteArrayOneLine( int[ ] a, string indexName, string arrayName, bool showIndex = true )
        {
            if( a == null ) return;
            if( string.IsNullOrEmpty( indexName ) ) indexName = "i";
            if( string.IsNullOrEmpty( arrayName ) ) arrayName = "a";
            int nameLength = Math.Max( indexName.Length, arrayName.Length );
            string fmt = "{0," + nameLength + "}:";

            if( showIndex )
            {
                if( a.Length >  0 ) Write( fmt, indexName );
                if( a.Length >  0 ) Write( $" {0,8}" );
                if( a.Length >  1 ) Write( $" {1,8}" );
                if( a.Length >  2 ) Write( $" {2,8}" );
                if( a.Length >  3 ) Write( $" {3,8}" );
                if( a.Length >  4 ) Write( $" {4,8}" );
                if( a.Length > 10 ) Write( " ..." );
                if( a.Length >  9 ) Write( $" {(a.Length - 5),8}" );
                if( a.Length >  8 ) Write( $" {(a.Length - 4),8}" );
                if( a.Length >  7 ) Write( $" {(a.Length - 3),8}" );
                if( a.Length >  6 ) Write( $" {(a.Length - 2),8}" );
                if( a.Length >  5 ) Write( $" {(a.Length - 1),8}" );
                WriteLine( );
            }

            if( a.Length >  0 ) Write( fmt, arrayName );
            if( a.Length >  0 ) Write( $" {a[ 0 ],8}" );
            if( a.Length >  1 ) Write( $" {a[ 1 ],8}" );
            if( a.Length >  2 ) Write( $" {a[ 2 ],8}" );
            if( a.Length >  3 ) Write( $" {a[ 3 ],8}" );
            if( a.Length >  4 ) Write( $" {a[ 4 ],8}" );
            if( a.Length > 10 ) Write( " ..." );
            if( a.Length >  9 ) Write( $" {a[ a.Length - 5 ],8}" );
            if( a.Length >  8 ) Write( $" {a[ a.Length - 4 ],8}" );
            if( a.Length >  7 ) Write( $" {a[ a.Length - 3 ],8}" );
            if( a.Length >  6 ) Write( $" {a[ a.Length - 2 ],8}" );
            if( a.Length >  5 ) Write( $" {a[ a.Length - 1 ],8}" );
            WriteLine( );
        }

        // Method SelectSort is used to sort an array of integers.

        static void SelectSort( int [ ] originalArr, out int [ ] swaps )                         
        {   
            //To assign some initial value to out parameter before we check for Original Arr then set it to actual value
            swaps = new int [0];
            
            // Basic error checking
            if( originalArr == null ) return;                                                   
            if( originalArr.Length < 2 ) return;
            
            //Need to initialize this new array passed into the method which qs tells us has length
            swaps = new int [originalArr.Length - 1];
            
            for( int firstUnsorted = 0; firstUnsorted < originalArr.Length - 1; firstUnsorted ++ )
            {
                // Follow code we know on how to locate minimal value in an array
                int min = firstUnsorted;
                for( int i = firstUnsorted + 1; i < originalArr.Length; i ++ )
                {
                    if( Compare( originalArr[ i ], originalArr[ min ] ) < 0 )
                    {
                        min = i;
                    }
                    //Location of minimal value in unsorted region located so we can now do the swapping with the classic 3 line of code:
                }
                
                //Swapping to make Org Array a Sorted Array
                int temp = originalArr[ min ];
                originalArr[ min ] = originalArr[ firstUnsorted ];
                originalArr[ firstUnsorted ] = temp;
                
                swaps [ firstUnsorted ] = min;               
                
            }
        }
        
        // Method UndoSelectSort receives an array and the swaps used in sorting it
        // by selection sort. It returns the array to its original unsorted order.
        
        static void UndoSelectSort(int [ ] originalArr, int [ ] swaps)
        {
            //Error checks with throwing an exception
            if( swaps == null ) 
            {   
                throw new ArgumentOutOfRangeException( nameof ( swaps ), "Null!" );
            }

            if( swaps.Length < 2 ) //already sorted 
            {
                throw new ArgumentOutOfRangeException( nameof ( swaps ), "The array size is too small." );
            }
            //No sorting needed so dont check for minimum using  for loop
            
// Unsporting you go from end to beginning but same steps for swapping            
            // go reverse of sorting / Unsorting
            for ( int i = swaps.Length - 1; i >= 0; i --)
            {   
                int temp =  originalArr [i]; 
                originalArr [i] = originalArr[ swaps [i] ];
                originalArr [ swaps  [ i ] ] = temp;
            }
        }
            
        // Method Main is used to test selection sorting and its undoing.
        static void Main( )
        {
            //int[ ] data = NewRandomArray( size: 10, range: 100 );
            int [ ] data = new int [10] {4,0,48,49,17,53,61,78,56,6};
            
            WriteLine( );
            WriteLine( "Original array" );
            WriteArrayOneLine( data, "i", nameof( data ) );

            SelectSort( data, out int [ ] exchange );
            WriteLine( );
            WriteLine( "Exchange array" );
            WriteArrayOneLine( exchange, "i", "Exch" );

            
            WriteLine( );
            WriteLine( "Sorted array" );
            WriteArrayOneLine( data, "i", nameof( data ) );
            
            UndoSelectSort(data, exchange );
            WriteLine( );
            WriteLine( "Unsorted array" );
            WriteArrayOneLine( data, "i", nameof( data ) );
        }

        // Method Compare is the comparison used in sorting.
        static int Compare( int a, int b )
        {
            return a.CompareTo( b );
        }
    }
}





using Day5;

var columns = new Stack<char>[9];

InitialiseStack();
FirstStar.Get(columns);

InitialiseStack();
Console.WriteLine();
SecondStar.Get(columns);

void InitialiseStack()
{
    columns[0] = new Stack<char>(new[] { 'Q', 'F', 'M', 'R', 'L', 'W', 'C', 'V' });
    columns[1] = new Stack<char>(new[] { 'D', 'Q', 'L' });
    columns[2] = new Stack<char>(new[] { 'P', 'S', 'R', 'G', 'W', 'C', 'N', 'B' });
    columns[3] = new Stack<char>(new[] { 'L', 'C', 'D', 'H', 'B', 'Q', 'G' });
    columns[4] = new Stack<char>(new[] { 'V', 'G', 'L', 'F', 'Z', 'S' });
    columns[5] = new Stack<char>(new[] { 'D', 'G', 'N', 'P' });
    columns[6] = new Stack<char>(new[] { 'D', 'Z', 'P', 'V', 'F', 'C', 'W' });
    columns[7] = new Stack<char>(new[] { 'C', 'P', 'D', 'M', 'S' });
    columns[8] = new Stack<char>(new[] { 'Z', 'N', 'W', 'T', 'V', 'M', 'P', 'C' });
}

#include <iostream>
#include <fstream>
#include <list>
#include <chrono>
using namespace std;
using namespace std::chrono;

// Ferry class
class Ferry
{
    int index;              // Ferry index
    int carsCapacity;       // Cars capacity in a ferry
    int time;               // Time to cross the river back and forth
    int carsAtTheTerminal;  // Number of cars waiting at the terminal
    int arrivalTimes[1440]; // Cars' arrival times to the ferry

public:
    // Constructor
    Ferry(const int& ind, const int& cap, const int& ti, int& carsNumber, int times[]) :
        index(ind),
        carsCapacity(cap),
        time(ti * 2),
        carsAtTheTerminal(carsNumber)
    {
        for (int i = 0; i < carsNumber; i++)
        {
            arrivalTimes[i] = times[i];
        }
    }

    // Counts the time needed to ferry all the cars
    int TimeToDeliver()
    {
        int position = (carsAtTheTerminal + carsCapacity - 1) % carsCapacity;

        int totalTime = 0;
        int actualTime = 0;
        for (int i = position; i < carsAtTheTerminal; i += carsCapacity)
        {
            if (totalTime > arrivalTimes[i])
            {
                actualTime = totalTime;
            }
            else
            {
                actualTime = arrivalTimes[i];
                totalTime = actualTime + time;
            }
        }
        return totalTime - time / 2;
    }

    // Counts the quantity of trips needed to ferry all the cars
    int TripsCount()
    {
        return (carsAtTheTerminal + carsCapacity - 1) / carsCapacity;
    }

};

// Terminal class
class Terminal
{
    list<Ferry> allFerries;         // List of all ferries in a terminal

public:
    // Constructor
    Terminal() :
        allFerries() {}

    // Adds ferry to the terminal
    void AddFerry(Ferry ferry)
    {
        allFerries.push_back(ferry);
    }

};

// Prints result of one case
void PrintResult(string outputFile, int totalTime,
    int trips, bool append)
{
    ofstream result;
    if (append)
        result.open(outputFile, ios_base::app);
    else
        result.open(outputFile);
    result << totalTime << " " << trips << endl;
    return;
}


// Reads data and performs task
void ReadAndPerform(string inputFile, string outputFile)
{
    int c; // Number of test cases
    int n; // Number of cars, that can fit into the ferry
    int t; // Time to cross the river
    int m; // Cars at the terminal

    ifstream data(inputFile);
    data >> c;
    for (int i = 0; i < c; i++)
    {
        data >> n >> t >> m;

        int carsArrivalTimes[1440];
        for (int j = 0; j < m; j++)
        {
            data >> carsArrivalTimes[j];
        }

        Terminal terminal = Terminal();
        Ferry ferry = Ferry(c, n, t, m, carsArrivalTimes);
        terminal.AddFerry(ferry);

        int totalTime = ferry.TimeToDeliver();
        int tripsCount = ferry.TripsCount();

        bool append = false;
        if (i > 0)
            append = true;
        PrintResult(outputFile, totalTime, tripsCount, append);
    }

    data.close();
    return;
}


int main()
{
    string inputFile = "Data.txt";
    string outputFile = "Results.txt";

    // Duration of operations start point
    auto start = high_resolution_clock::now();

    // Main calculations method
    ReadAndPerform(inputFile, outputFile);

    // Duration of operations end point
    auto stop = high_resolution_clock::now();
    // Duration
    auto duration = duration_cast<microseconds>(stop - start);
    cout << "Time taken by function: "
         << duration.count() << " microseconds" << endl;

    return 0;
}

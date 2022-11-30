#include <iostream>
#include <fstream>
#include <string>
#include <sstream>
#include <vector>
using namespace std;


float get_score(float wave, float wind, float wtemp, float temp) {
    int a, b, c, d;
    bool rflag = true;
    if (wave < 0.5)
        a = 5;
    else if (wave < 1)
        a = 4;
    else if (wave < 1.5)
        a = 3;
    else if (wave < 2)
        a = 2;
    else
        a = 1;
    if (wind < 2)
        b = 5;
    else if (wind < 5)
        b = 4;
    else if (wind < 8)
        b = 3;
    else if (wind < 10)
        b = 2;
    else
        b = 1;
    if (wtemp >= 22)
        c = 5;
    else if (wtemp >= 20)
        c = 4;
    else if (wtemp >= 18)
        c = 3;
    else if (wtemp >= 14) {
        c = 2;
        if (wtemp < 16)
            rflag = false;
    }
    else {
        rflag = false;
        c = 1;
    }
    if (temp >= 27)
        d = 5;
    else if (temp >= 24)
        d = 4;
    else if (temp >= 22)
        d = 3;
    else if (temp >= 20)
        d = 2;
    else
        d = 1;
    //edit weight
    if (rflag)
        return a * 2.2 + b * 1.2 + c * 0.4 + d * 0.2;
    else
        return a * 1.8 + b * 1.0 + c * 1.0 + d * 0.2;
}

int main() {
   
    float B_wtemp, B_temp, B_wave, B_wind;
    ifstream readF;
    ofstream outF;
    readF.open("data_2020_TW_TW_NAKSAN_202008_KR.txt");
    int day_cnt = 0;
    float sum_score = 0;
    vector<float> day_score;

    if (readF.is_open()) {
        while (!readF.eof()) {
            string line;
            getline(readF, line);
                istringstream ist(line);
                vector<string> line_v;
                string tmp,nline;
                //now parse sentence by tab, maybe default is space?
                while (getline(ist, tmp, '\t'))
                    line_v.push_back(tmp);

                day_cnt++;
                cout << "now day is : " << line_v[0] << endl;
                //edit idx depend on file
                B_wtemp = stof(line_v[1]);
         
                B_wave = stof(line_v[2]);
                
                B_wind = stof(line_v[3]);
                
                B_temp = stof(line_v[4]);
               
                //scale point
                float day_s= (get_score(B_wave, B_wind, B_wtemp, B_temp)) / 3.7;
                day_score.push_back(day_s);
                
                //might be error point
                //add "end" at final line?
                /*if (line_v[0] == "2020-08-31 15:00:00") {
                    printf("End\n");
                    break;
                }*/
            
            
        }
        outF.open("result.txt");
        float ssum = 0;
        for (int i = 0; i < day_score.size(); i++) {
            outF << i << "th day score : " << day_score[i] << endl;
            //printf("%f\n", day_score[i]); 
            ssum += day_score[i];
        }
        outF << "Month score avg : " << ssum / day_score.size() << endl;

        readF.close();
    }
   
    return 0;
}
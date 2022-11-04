#include <iostream>
using namespace std;

int argu[4];
void getData(){
    cin>>argu[0]>>argu[1]>>argu[2]>>argu[3];
}

int getWSum(){
    int wave=2.2;
    int wind=1.2;
    int water_temp=0.4;
    int temp=0.2;
    return wave*argu[0]+wind*argu[1]*water_temp*argu[2]+temp*argu[3];
}
int main(){
    getData();
    printf("%d\n",getWSum());
}
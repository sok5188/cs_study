
#include <iostream>
#include <cstring>
#include <vector>
using namespace std;

int main()
{
    char S[256];
    char K[256];
    char key[] = "breakcode";
    char plainText[] = "seoul98";
    vector<char> KeyStream(strlen(plainText));

    cout << "key : " << key << endl;
    cout << "plaintext : " << plainText << endl;

    int i, j;
    i = j = 0;
    for (i = 0; i < 256; i++) {
        S[i] = i;
        K[i] = key[i % strlen(key)];
    }

    for (i = 0, j = 0; i < 256; i++) {
        j = (j + S[i] + K[i]) % 256;
        swap(S[i], S[j]);
    }
    i = j = 0;
    for (int k = 0; k < strlen(plainText); k++)
    {
        i = (i + 1) % 256;
        j = (j + S[i]) % 256;
        swap(S[i], S[j]);

        int idx = (S[i] + S[j]) % 256;
        KeyStream[k] = S[idx];
        plainText[k] ^= S[KeyStream[k]];

        cout << (k + 1) << "th KeyStream :  " << (unsigned int)KeyStream[k] << endl;
    }

    cout << endl << "Cipher Text  :  " << plainText << endl;

    for (int k = 0; k < strlen(plainText); k++) {
        plainText[k] ^= S[KeyStream[k]];
    }

    cout << endl << "Decrypt Text :  " << plainText << endl;

    exit(0);
}
#include<iostream>
#include<string>
#include<vector>
#include<bitset>

using namespace std;
string K[17], L[17], R[17];
static const unsigned int Init_Key_Sel[64] =
{

    57, 49, 41, 33, 25, 17,  9,
    1, 58, 50, 42, 34, 26, 18,
    10,  2, 59, 51, 43, 35, 27,
    19, 11,  3, 60, 52, 44, 36,
    63, 55, 47, 39, 31, 23, 15,
    7, 62, 54, 46, 38, 30, 22,
    14,  6, 61, 53, 45, 37, 29,
    21, 13,  5, 28, 20, 12,  4
};
static const unsigned int LSHIFT[] =
{
    1,1,2,2,
    2,2,2,2,
    1,2,2,2,
    2,2,2,1
};
static const unsigned int Permute_Comp[48] =
{
    14, 17, 11, 24,  1,  5,  3, 28,
    15,  6, 21, 10, 23, 19, 12,  4,
    26,  8, 16,  7, 27, 20, 13,  2,
    41, 52, 31, 37, 47, 55, 30, 40,
    51, 45, 33, 48, 44, 49, 39, 56,
    34, 53, 46, 42, 50, 36, 29, 32,
};
static const unsigned int Init_Text_Permute[64] =
{
    58, 50, 42, 34, 26, 18, 10,  2,
    60, 52, 44, 36, 28, 20, 12,  4,
    62, 54, 46, 38, 30, 22, 14,  6,
    64, 56, 48, 40, 32, 24, 16,  8,
    57, 49, 41, 33, 25, 17,  9,  1,
    59, 51, 43, 35, 27, 19, 11,  3,
    61, 53, 45, 37, 29, 21, 13,  5,
    63, 55, 47, 39, 31, 23, 15,  7
};
static const unsigned int Expansion_Permute[64] =
{
   32,1 ,2 ,3 ,4 ,5,
    4 ,5 ,6 ,7 ,8 ,9,
    8 ,9, 10, 11, 12, 13,
    12, 13, 14, 15, 16, 17,
    16, 17, 18, 19, 20, 21,
    20, 21, 22, 23, 24, 25,
    24, 25, 26 ,27, 28, 29,
    28, 29, 30 ,31, 32, 1
};
static const unsigned int SBox[8][4][16] =
{
    /* S-Box [1] */
    { { 14,4,13,1,2,15,11,8,3,10,6,12,5,9,0,7 },
    { 0,15,7,4,14,2,13,1,10,6,12,11,9,5,3,8 },
    { 4,1,14,8,13,6,2,11,15,12,9,7,3,10,5,0 },
    { 15,12,8,2,4,9,1,7,5,11,3,14,10,0,6,13 } },
    /* S-Box [2] */
    { { 15,1,8,14,6,11,3,4,9,7,2,13,12,0,5,10 },
    { 3,13,4,7,15,2,8,14,12,0,1,10,6,9,11,5 },
    { 0,14,7,11,10,4,13,1,5,8,12,6,9,3,2,15 },
    { 13,8,10,1,3,15,4,2,11,6,7,12,0,5,14,9 } },
    /* S-Box [3] */
    { { 10,0,9,14,6,3,15,5,1,13,12,7,11,4,2,8 },
    { 13,7,0,9,3,4,6,10,2,8,5,14,12,11,15,1 },
    { 13,6,4,9,8,15,3,0,11,1,2,12,5,10,14,7 },
    { 1,10,13,0,6,9,8,7,4,15,14,3,11,5,2,12 } },
    /* S-Box [4] */
    { { 7,13,14,3,0,6,9,10,1,2,8,5,11,12,4,15 },
    { 13,8,11,5,6,15,0,3,4,7,2,12,1,10,14,9 },
    { 10,6,9,0,12,11,7,13,15,1,3,14,5,2,8,4 },
    { 3,15,0,6,10,1,13,8,9,4,5,11,12,7,2,14 } },
    /* S-Box [5] */
    { { 2,12,4,1,7,10,11,6,8,5,3,15,13,0,14,9 },
    { 14,11,2,12,4,7,13,1,5,0,15,10,3,9,8,6 },
    { 4,2,1,11,10,13,7,8,15,9,12,5,6,3,0,14 },
    { 11,8,12,7,1,14,2,13,6,15,0,9,10,4,5,3 } },
    /* S-Box [6] */
    { { 12,1,10,15,9,2,6,8,0,13,3,4,14,7,5,11 },
    { 10,15,4,2,7,12,9,5,6,1,13,14,0,11,3,8 },
    { 9,14,15,5,2,8,12,3,7,0,4,10,1,13,11,6 },
    { 4,3,2,12,9,5,15,10,11,14,1,7,6,0,8,13 } },
    /* S-Box [7] */
    { { 4,11,2,14,15,0,8,13,3,12,9,7,5,10,6,1 },
    { 13,0,11,7,4,9,1,10,14,3,5,12,2,15,8,6 },
    { 1,4,11,13,12,3,7,14,10,15,6,8,0,5,9,2 },
    { 6,11,13,8,1,4,10,7,9,5,0,15,14,2,3,12 } },
    /* S-Box [8] */
    { { 13,2,8,4,6,15,11,1,10,9,3,14,5,0,12,7 },
    { 1,15,13,8,10,3,7,4,12,5,6,11,0,14,9,2 },
    { 7,11,4,1,9,12,14,2,0,6,10,13,15,3,5,8 },
    { 2,1,14,7,4,10,8,13,15,12,9,0,3,5,6,11 } }
};
static const unsigned int Permute_pbox[32] =
{
    16,  7, 20, 21, 29, 12, 28, 17,
    1, 15, 23, 26,  5, 18, 31, 10,
    2,  8, 24, 14, 32, 27,  3,  9,
    19, 13, 30,  6, 22, 11,  4, 25
};
static const unsigned int Permute_Inverse[64] =
{
    40,  8, 48, 16, 56, 24, 64, 32,
    39,  7, 47, 15, 55, 23, 63, 31,
    38,  6, 46, 14, 54, 22, 62, 30,
    37,  5, 45, 13, 53, 21, 61, 29,
    36,  4, 44, 12, 52, 20, 60, 28,
    35,  3, 43, 11, 51, 19, 59, 27,
    34,  2, 42, 10, 50, 18, 58, 26,
    33,  1, 41,  9, 49, 17, 57, 25
};
string hex_to_bin(string s) {
    string ans;
    for (int i = 0; i < s.size(); i++) {
        switch (s.at(i))
        {
        case '0':
            ans.append("0000");
            break;
        case '1':
            ans.append("0001");
            break;
        case '2':
            ans.append("0010");
            break;
        case '3':
            ans.append("0011");
            break;
        case '4':
            ans.append("0100");
            break;
        case '5':
            ans.append("0101");
            break;
        case '6':
            ans.append("0110");
            break;
        case '7':
            ans.append("0111");
            break;
        case '8':
            ans.append("1000");
            break;
        case '9':
            ans.append("1001");
            break;
        case 'A':
            ans.append("1010");
            break;
        case 'B':
            ans.append("1011");
            break;
        case 'C':
            ans.append("1100");
            break;
        case 'D':
            ans.append("1101");
            break;
        case 'E':
            ans.append("1110");
            break;
        case 'F':
            ans.append("1111");
            break;
        default:
            break;
        }
    }
    return ans;
}
string bin_to_hex(string s) {
    string ans;
    for (int i = 0; i < s.size(); i += 4) {
        string tmp = s.substr(i, 4);
        if (tmp == "0000") {
            ans += '0';
        }
        else if (tmp == "0001") {
            ans += '1';
        }
        else if (tmp == "0010") {
            ans += '2';
        }
        else if (tmp == "0011") {
            ans += '3';
        }
        else if (tmp == "0100") {
            ans += '4';
        }
        else if (tmp == "0101") {
            ans += '5';
        }
        else if (tmp == "0110") {
            ans += '6';
        }
        else if (tmp == "0111") {
            ans += '7';
        }
        else if (tmp == "1000") {
            ans += '8';
        }
        else if (tmp == "1001") {
            ans += '9';
        }
        else if (tmp == "1010") {
            ans += 'A';
        }
        else if (tmp == "1011") {
            ans += 'B';
        }
        else if (tmp == "1100") {
            ans += 'C';
        }
        else if (tmp == "1101") {
            ans += 'D';
        }
        else if (tmp == "1110") {
            ans += 'E';
        }
        else if (tmp == "1111") {
            ans += 'F';
        }


    }
    return ans;
}
string initial_key(string key) {

    string ans;
    for (int i = 0; i < 56; i++) {
        char tmp = key.at(Init_Key_Sel[i] - 1);
        ans += (tmp);
    }
    return ans;
}
string shift_key(string* key, int round) {

    int num = LSHIFT[round];
    string left, right;
    string k = *key;
    left = k.substr(0, 28);
    right = k.substr(28);
    while (num--) {
        char tmp = left.at(0);
        left.erase(0, 1);
        left += tmp;
        char tmp2 = right.at(0);
        right.erase(0, 1);
        right += tmp2;
    }
    k = left + right;
    *key = k;
    return  k;
}
string permute_key(string key) {
    string ans;
    for (int i = 0; i < 48; i++) {
        ans += key.at(Permute_Comp[i] - 1);
    }
    return ans;
}
string Init_permute_text(string text) {
    string ans;
    for (int i = 0; i < 64; i++) {
        ans += text.at(Init_Text_Permute[i] - 1);
    }
    return ans;
}
string expanse_text(string text) {
    string ans;
    for (int i = 0; i < 48; i++) {
        ans += text.at(Expansion_Permute[i] - 1);
    }
    return ans;
}
string xor_text(string s1, string s2) {
    string ans;
    for (int i = 0; i < s1.size(); i++) {
        if (s1.at(i) == s2.at(i)) {
            ans += '0';
        }
        else ans += '1';
    }
    return ans;
}

string sbox(string text) {
    string ans;
    int cnt = 0;
    for (int i = 0; i < text.size(); i += 6, cnt++) {
        int row = (text.at(i) - '0') * 2 + (text.at(i + 5) - '0');
        int col = (text.at(i + 1) - '0') * 8 + (text.at(i + 2) - '0') * 4 + (text.at(i + 3) - '0') * 2 + (text.at(i + 4) - '0');
        int sb = SBox[cnt][row][col];

        ans += bitset<4>(sb).to_string();

    }
    return ans;
}
string permute_text(string text) {
    string ans;
    for (int i = 0; i < 32; i++) {
        ans += text.at(Permute_pbox[i] - 1);
    }
    return ans;
}
string inverse_permute_text(string text) {
    string ans;
    for (int i = 0; i < 64; i++) {
        ans += text.at(Permute_Inverse[i] - 1);
    }
    return ans;
}
int main() {
    string plaintext, key;
    cout << "plaintext : ";
    cin >> plaintext;
    cout << "key :";
    cin >> key;
   /* plaintext = "0123456789ABCDEF";
    key = "133457799BBCDFF1";*/
    string bin_key = hex_to_bin(key);
    string key_v = initial_key(bin_key);    

    for (int i = 0; i < 16; i++) {
        string key_s = shift_key(&key_v, i);
        K[i] = permute_key(key_s);
    }


    string bin_text = hex_to_bin(plaintext);
    string init_text = Init_permute_text(bin_text);
    L[0] = init_text.substr(0, 32);
    R[0] = init_text.substr(32);
    for (int i = 0; i < 16; i++) {
        L[i + 1] = R[i];
        string expansion = expanse_text(R[i]);

        string F_text = xor_text(expansion, K[i]);

        string sbox_text = sbox(F_text);

        string P_text = permute_text(sbox_text);

        R[i + 1] = xor_text(L[i], P_text);

    }
    string lastL, lastR;
    lastL = R[16];
    lastR = L[16];
    string lastT = lastL + lastR;
    string cipher_text = inverse_permute_text(lastT);
    cout << "cipher text is : " << cipher_text << endl;
    string hex_cipher = bin_to_hex(cipher_text);
    cout << "cipher(hex) is : " << hex_cipher << endl;
    return 0;
}
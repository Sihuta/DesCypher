using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BPDT_lab1.DES
{
    public class DesCipher
    {
        public double[] RoundsEntropy { get; private set; } = new double[RoundsNum];

        // Initial Permutation
        private readonly int[] IP =
        {
            58, 50, 42, 34, 26, 18, 10, 2, 60, 52, 44, 36, 28, 20, 12, 4,
            62, 54, 46, 38, 30, 22, 14, 6, 64, 56, 48, 40, 32, 24, 16, 8,
            57, 49, 41, 33, 25, 17, 9,  1, 59, 51, 43, 35, 27, 19, 11, 3,
            61, 53, 45, 37, 29, 21, 13, 5, 63, 55, 47, 39, 31, 23, 15, 7
        };

        // Final Permutation
        private readonly int[] FP =
        {
            40, 8, 48, 16, 56, 24, 64, 32, 39, 7, 47, 15, 55, 23, 63, 31,
            38, 6, 46, 14, 54, 22, 62, 30, 37, 5, 45, 13, 53, 21, 61, 29,
            36, 4, 44, 12, 52, 20, 60, 28, 35, 3, 43, 11, 51, 19, 59, 27,
            34, 2, 42, 10, 50, 18, 58, 26, 33, 1, 41, 9,  49, 17, 57, 25
        };

        // 1st Key Permutation
        private readonly int[] KP1 =
        {
            57, 49, 41, 33, 25, 17, 9,  1,  58, 50, 42, 34, 26, 18,
            10, 2,  59, 51, 43, 35, 27, 19, 11, 3,  60, 52, 44, 36,
            63, 55, 47, 39, 31, 23, 15, 7,  62, 54, 46, 38, 30, 22,
            14, 6,  61, 53, 45, 37, 29, 21, 13, 5,  28, 20, 12, 4
        };

        // 2nd Key Permutation
        private readonly int[] KP2 =
        {
            14, 17, 11, 24, 1,  5,  3,  28, 15, 6,  21, 10, 23, 19, 12, 4,
            26, 8,  16, 7,  27, 20, 13, 2,  41, 52, 31, 37, 47, 55, 30, 40,
            51, 45, 33, 48, 44, 49, 39, 56, 34, 53, 46, 42, 50, 36, 29, 32
        };

        // Expansion Permutation
        private readonly int[] EP =
        {
            32, 1,  2,  3,  4,  5,  4,  5,  6,  7,  8,  9,
            8,  9,  10, 11, 12, 13, 12, 13, 14, 15, 16, 17,
            16, 17, 18, 19, 20, 21, 20, 21, 22, 23, 24, 25,
            24, 25, 26, 27, 28, 29, 28, 29, 30, 31, 32, 1
        };

        // P-Box Permutation
        private readonly int[] P =
        {
            16, 7, 20, 21, 29, 12, 28, 17, 1,  15, 23, 26, 5,  18, 31, 10,
            2,  8, 24, 14, 32, 27, 3,  9,  19, 13, 30, 6,  22, 11, 4,  25
        };

        // Key Left Shifts
        private readonly int[] KeyShifts =
        {
            1, 1, 2, 2, 2, 2, 2, 2,
            1, 2, 2, 2, 2, 2, 2, 1
        };

        // S-Box Table
        private readonly int[][][] SBox = new int[][][] {
            new int[][] {
                new int[] { 14, 4,  13, 1, 2,  15, 11, 8,  3,  10, 6,  12, 5,  9,  0, 7 },
                new int[] { 0,  15, 7,  4, 14, 2,  13, 1,  10, 6,  12, 11, 9,  5,  3, 8 },
                new int[] { 4,  1,  14, 8, 13, 6,  2,  11, 15, 12, 9,  7,  3,  10, 5, 0 },
                new int[] { 15, 12, 8,  2, 4,  9,  1,  7,  5,  11, 3,  14, 10, 0,  6, 13 }
            },
            new int[][] {
                new int[] { 15, 1,  8,  14, 6,  11, 3,  4,  9,  7, 2,  13, 12, 0, 5,  10 },
                new int[] { 3,  13, 4,  7,  15, 2,  8,  14, 12, 0, 1,  10, 6,  9, 11, 5 },
                new int[] { 0,  14, 7,  11, 10, 4,  13, 1,  5,  8, 12, 6,  9,  3, 2,  15 },
                new int[] { 13, 8,  10, 1,  3,  15, 4,  2,  11, 6, 7,  12, 0,  5, 14, 9 }
            },
            new int[][] {
                new int[] { 10, 0,  9,  14, 6, 3,  15, 5,  1,  13, 12, 7,  11, 4,  2,  8 },
                new int[] { 13, 7,  0,  9,  3, 4,  6,  10, 2,  8,  5,  14, 12, 11, 15, 1 },
                new int[] { 13, 6,  4,  9,  8, 15, 3,  0,  11, 1,  2,  12, 5,  10, 14, 7 },
                new int[] { 1,  10, 13, 0,  6, 9,  8,  7,  4,  15, 14, 3,  11, 5,  2,  12 }
            },
            new int[][] {
                new int[] { 7,  13, 14, 3, 0,  6,  9,  10, 1,  2, 8, 5,  11, 12, 4,  15 },
                new int[] { 13, 8,  11, 5, 6,  15, 0,  3,  4,  7, 2, 12, 1,  10, 14, 9 },
                new int[] { 10, 6,  9,  0, 12, 11, 7,  13, 15, 1, 3, 14, 5,  2,  8,  4 },
                new int[] { 3,  15, 0,  6, 10, 1,  13, 8,  9,  4, 5, 11, 12, 7,  2,  14 }
            },
            new int[][] {
                new int[] { 2,  12, 4,  1,  7,  10, 11, 6,  8,  5,  3,  15, 13, 0, 14, 9 },
                new int[] { 14, 11, 2,  12, 4,  7,  13, 1,  5,  0,  15, 10, 3,  9, 8,  6 },
                new int[] { 4,  2,  1,  11, 10, 13, 7,  8,  15, 9,  12, 5,  6,  3, 0,  14 },
                new int[] { 11, 8,  12, 7,  1,  14, 2,  13, 6,  15, 0,  9,  10, 4, 5,  3 }
            },
            new int[][] {
                new int[] { 12, 1,  10, 15, 9, 2,  6,  8,  0,  13, 3,  4,  14, 7,  5,  11 },
                new int[] { 10, 15, 4,  2,  7, 12, 9,  5,  6,  1,  13, 14, 0,  11, 3,  8 },
                new int[] { 9,  14, 15, 5,  2, 8,  12, 3,  7,  0,  4,  10, 1,  13, 11, 6 },
                new int[] { 4,  3,  2,  12, 9, 5,  15, 10, 11, 14, 1,  7,  6,  0,  8,  13 }
            },
            new int[][] {
                new int[] { 4,  11, 2,  14, 15, 0, 8,  13, 3,  12, 9, 7,  5,  10, 6, 1 },
                new int[] { 13, 0,  11, 7,  4,  9, 1,  10, 14, 3,  5, 12, 2,  15, 8, 6 },
                new int[] { 1,  4,  11, 13, 12, 3, 7,  14, 10, 15, 6, 8,  0,  5,  9, 2 },
                new int[] { 6,  11, 13, 8,  1,  4, 10, 7,  9,  5,  0, 15, 14, 2,  3, 12 }
            },
            new int[][] {
                new int[] { 13, 2,  8,  4, 6,  15, 11, 1,  10, 9,  3,  14, 5,  0,  12, 7 },
                new int[] { 1,  15, 13, 8, 10, 3,  7,  4,  12, 5,  6,  11, 0,  14, 9,  2 },
                new int[] { 7,  11, 4,  1, 9,  12, 14, 2,  0,  6,  10, 13, 15, 3,  5,  8 },
                new int[] { 2,  1, 14,  7, 4,  10, 8,  13, 15, 12, 9,  0,  3,  5,  6,  11 }
            }
        };

        private const int RoundsNum = 16;
        private const int BlockSize = 64;
        private const int HalfBlockSize = BlockSize / 2;

        private delegate string CipherOperation(string text, string key);

        public string Cipher(string text, string key, bool encrypt = true)
        {
            CipherOperation cipherOperation = encrypt ?
                new CipherOperation(Encrypt) :
                new CipherOperation(Decrypt);

            text = encrypt ?
                Converter.StringToBinary(text) :
                Converter.HexToBin(text);
            key = Converter.StringToBinary(key);

            text = GetRightSizeText(text);
            key = GetRightSizeKey(key);

            var result = new StringBuilder(text.Length);

            for (int i = 0; i < text.Length; i += BlockSize)
            {
                string cipherBlock = text.Substring(i, BlockSize);
                result.Append(cipherOperation?.Invoke(cipherBlock, key));
            }

            return encrypt ?
                Converter.BinToHex(result.ToString()).Trim() :
                Converter.BinaryToString(result.ToString()).Trim();
        }

        private string GetRightSizeText(string text)
        {
            int mod = text.Length % BlockSize;
            if (mod == 0)
            {
                return text;
            }

            int totalLength = text.Length + (BlockSize - mod);
            return text.PadRight(totalLength, '0');
        }

        private string GetRightSizeKey(string key)
        {
            if (key == null || key.Length == 0)
            {
                return null;
            }

            if (key.Length == BlockSize)
            {
                return key;
            }
            if (key.Length > BlockSize)
            {
                return key[..BlockSize];
            }

            var res = new StringBuilder(key);
            int n = BlockSize - key.Length;
            int j = 0;

            for (int i = 0; i < n; i++)
            {
                res.Append(key[j]);
                j = (j + 1) % key.Length;
            }
            return res.ToString();
        }

        private string Encrypt(string text, string key)
        {
            string[] keys = GenerateKeys(key);

            int distinctKeys;
            if ((distinctKeys = keys.Distinct().Count()) < 5)
            {
                throw new WeakKeyException($"The key is weak! Only {distinctKeys}/{keys.Length} different subkeys were generated.");
            }

            // initial permutation
            text = Permute(IP, text);
            for (int i = 0; i < RoundsNum; ++i)
            {
                text = FeistelRound(text, keys[i], i);
            }

            // 32-bit swap
            string left = text[..HalfBlockSize];
            string right = text.Substring(HalfBlockSize, HalfBlockSize);
            text = right + left;

            // final permutation
            text = Permute(FP, text);
            return text;
        }

        private string Decrypt(string text, string key)
        {
            string[] keys = GenerateKeys(key);

            // initial permutation
            text = Permute(IP, text);
            for (int i = RoundsNum - 1; i >= 0; --i)
            {
                text = FeistelRound(text, keys[i], (RoundsNum - 1) - i);
            }

            // 32-bit swap
            string left = text[..HalfBlockSize];
            string right = text.Substring(HalfBlockSize, HalfBlockSize);
            text = right + left;

            // final permutation
            text = Permute(FP, text);
            return text;
        }

        private string FeistelRound(string input, string key, int roundNum)
        {
            string left = input[..HalfBlockSize];
            string right = input.Substring(HalfBlockSize, HalfBlockSize);
            string temp = right;

            // Expansion permutation
            temp = Permute(EP, temp);

            temp = Xor(temp, key);
            temp = Sbox(temp);

            // Straight D-box permutation
            temp = Permute(P, temp);
            left = Xor(left, temp);

            RoundsEntropy[roundNum] = GetRoundEntropy(right + left);

            // swap
            return right + left;
        }

        private double GetRoundEntropy(string binaryInput)
        {
            return (double) binaryInput.Count(i => i == '1') / binaryInput.Length;
        }

        private string Xor(string a, string b)
        {
            int n = a.Length;
            var res = new StringBuilder(n);

            for (int i = 0; i < n; ++i)
            {
                if (a[i] == b[i])
                {
                    res.Append('0');
                }
                else
                {
                    res.Append('1');
                }
            }
            return res.ToString();
        }

        private string Sbox(string input)
        {
            int binBase = 2;
            int blockSize = 6;
            int newBlockSize = 4;
            var res = new StringBuilder();

            for (int i = 0; i < input.Length; i += blockSize)
            {
                string temp = input.Substring(i, blockSize);

                int num = i / blockSize;
                int row = Convert.ToInt32(temp[0] + "" + temp[blockSize - 1], binBase);
                int col = Convert.ToInt32(temp.Substring(1, 4), binBase);

                string newBlock = Convert.ToString(SBox[num][row][col], binBase).PadLeft(newBlockSize, '0');

                res.Append(newBlock);
            }

            return res.ToString();
        }

        private string[] GenerateKeys(string key)
        {
            // 1st key permutation
            key = Permute(KP1, key);

            int halfBlockSize = key.Length / 2; // 28
            string[] keys = new string[RoundsNum];

            for (int i = 0; i < RoundsNum; ++i)
            {
                string left = key[..halfBlockSize];
                string right = key.Substring(halfBlockSize, halfBlockSize);

                key = LeftCircularShift(left, KeyShifts[i]) + LeftCircularShift(right, KeyShifts[i]);

                // 2nd key permutation
                keys[i] = Permute(KP2, key);
            }

            return keys;
        }

        private string[] GenerateDecryptKeys(string key)
        {
            // 1st key permutation
            key = Permute(KP1, key);

            int halfBlockSize = key.Length / 2; // 28
            string[] keys = new string[RoundsNum];

            for (int i = 0; i < RoundsNum; ++i)
            {
                string left = key[..halfBlockSize];
                string right = key.Substring(halfBlockSize, halfBlockSize);

                int j = RoundsNum - 1 - i;
                key = RightCircularShift(left, KeyShifts[j]) + RightCircularShift(right, KeyShifts[j]);

                // 2nd key permutation
                keys[i] = Permute(KP2, key);
            }

            return keys;
        }

        private string Permute(int[] sequence, string input)
        {
            var res = new StringBuilder(sequence.Length);
            for (int i = 0; i < sequence.Length; ++i)
            {
                res.Append(input[sequence[i] - 1]);
            }
            return res.ToString();
        }

        private string LeftCircularShift(string key, int shift)
        {
            shift %= key.Length;
            return key[shift..] + key[..shift];
        }

        private string RightCircularShift(string key, int shift)
        {
            shift %= key.Length;
            return key[^shift..] + key[..^shift];
        }
    }
}

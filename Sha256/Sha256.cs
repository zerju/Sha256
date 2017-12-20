﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sha256
{
    class Sha256
    {       
        // ostanki kubičnega korena prvih 64 praštevil
         static readonly uint[] constantsK = new uint[64] {
            0x428A2F98, 0x71374491, 0xB5C0FBCF, 0xE9B5DBA5, 0x3956C25B, 0x59F111F1, 0x923F82A4, 0xAB1C5ED5,
            0xD807AA98, 0x12835B01, 0x243185BE, 0x550C7DC3, 0x72BE5D74, 0x80DEB1FE, 0x9BDC06A7, 0xC19BF174,
            0xE49B69C1, 0xEFBE4786, 0x0FC19DC6, 0x240CA1CC, 0x2DE92C6F, 0x4A7484AA, 0x5CB0A9DC, 0x76F988DA,
            0x983E5152, 0xA831C66D, 0xB00327C8, 0xBF597FC7, 0xC6E00BF3, 0xD5A79147, 0x06CA6351, 0x14292967,
            0x27B70A85, 0x2E1B2138, 0x4D2C6DFC, 0x53380D13, 0x650A7354, 0x766A0ABB, 0x81C2C92E, 0x92722C85,
            0xA2BFE8A1, 0xA81A664B, 0xC24B8B70, 0xC76C51A3, 0xD192E819, 0xD6990624, 0xF40E3585, 0x106AA070,
            0x19A4C116, 0x1E376C08, 0x2748774C, 0x34B0BCB5, 0x391C0CB3, 0x4ED8AA4A, 0x5B9CCA4F, 0x682E6FF3,
            0x748F82EE, 0x78A5636F, 0x84C87814, 0x8CC70208, 0x90BEFFFA, 0xA4506CEB, 0xBEF9A3F7, 0xC67178F2
        };

        //inital hash value
        // prvih 32 bitov od delov ostanka od korena od prvih osem praštevil (hash value)
         uint[] initalHashValue = new uint[8] {
            0x6A09E667, 0xBB67AE85, 0x3C6EF372, 0xA54FF53A, 0x510E527F, 0x9B05688C, 0x1F83D9AB, 0x5BE0CD19
        };

         byte[] pending_block = new byte[64];
         uint pending_block_off = 0;
         uint[] buffer = new uint[16];

        public static uint bits_processed = 0;

         bool closed = false;

        public static List<byte> Hash(Stream stream)
        {
            Sha256 sha256 = new Sha256();
            byte[] buf = new byte[8196];

            uint bytes_read;
            do
            {
                bytes_read = (uint)stream.Read(buf, 0, buf.Length);
                // Console.WriteLine(bytes_read);
                if (bytes_read == 0) { 
                    break;
                }

                sha256.ProcessBytes(buf, 0, bytes_read);
            }
            while (bytes_read == 8196);

            return sha256.GetHash();
        }

        public void ProcessBytes(byte[] data, uint offset, uint len)
        {
            // Console.WriteLine(bits_processed);
            bits_processed += len * 8;

            while (len > 0)
            {
                uint amount_to_copy = 0;

                if (len < 64)
                {
                    if (pending_block_off + len > 64) { 
                        amount_to_copy = 64 - pending_block_off;
                    }
                    else { 
                        amount_to_copy = len;
                    }
                }
                else
                {
                    amount_to_copy = 64 - pending_block_off;
                }

                Array.Copy(data, offset, pending_block, pending_block_off, amount_to_copy);
                len -= amount_to_copy;
                offset += amount_to_copy;
                pending_block_off += amount_to_copy;

                if (pending_block_off == 64)
                {

                    toUintArray(pending_block, buffer);
                    processBlock(buffer);
                    pending_block_off = 0;
                }
            }
        }

         void processBlock(uint[] M)
        {
            
            uint[] W = new uint[64];
            for (int t = 0; t < 16; ++t)
            {
                W[t] = M[t];
            }

            for (int t = 16; t < 64; ++t)
            {
                W[t] = SmallSigma1(W[t - 2]) + W[t - 7] + SmallSigma0(W[t - 15]) + W[t - 16];
            }
            
            //working variables (8)
            uint a = initalHashValue[0];
            uint b = initalHashValue[1];
            uint c = initalHashValue[2];
            uint d = initalHashValue[3];
            uint e = initalHashValue[4];
            uint f = initalHashValue[5];
            uint g = initalHashValue[6];
            uint h = initalHashValue[7];
            
            for (int t = 0; t < 64; ++t)
            {
                uint T1 = h + BigSigma1(e) + Ch(e, f, g) + constantsK[t] + W[t];
                uint T2 = BigSigma0(a) + Maj(a, b, c);
                h = g;
                g = f;
                f = e;
                e = d + T1;
                d = c;
                c = b;
                b = a;
                a = T1 + T2;
            }
            
            initalHashValue[0] = a + initalHashValue[0];
            initalHashValue[1] = b + initalHashValue[1];
            initalHashValue[2] = c + initalHashValue[2];
            initalHashValue[3] = d + initalHashValue[3];
            initalHashValue[4] = e + initalHashValue[4];
            initalHashValue[5] = f + initalHashValue[5];
            initalHashValue[6] = g + initalHashValue[6];
            initalHashValue[7] = h + initalHashValue[7];
        }

        

        public List<byte> GetHash()
        {
            return toByteArray(GetHashUInt32());
        }

        public List<uint> GetHashUInt32()
        {
            if (!closed)
            {
                uint size_temp = bits_processed;

                ProcessBytes(new byte[1] { 0x80 }, 0, 1);

                uint available_space = 64 - pending_block_off;

                if (available_space < 8) { 
                    available_space += 64;
                }

                
                byte[] padding = new byte[available_space];
                
                //padding tako da je block multiple of 512
                for (uint i = 1; i <= 8; ++i)
                {
                    padding[padding.Length - i] = (byte)size_temp;
                    size_temp >>= 8;
                }

                ProcessBytes(padding, 0u, (uint)padding.Length);

                closed = true;
            }

            return initalHashValue.ToList();
        }

         static void toUintArray(byte[] src, uint[] dest)
        {
            for (uint i = 0, j = 0; i < dest.Length; ++i, j += 4)
            {
                dest[i] = ((uint)src[j + 0] << 24) | ((uint)src[j + 1] << 16) | ((uint)src[j + 2] << 8) | ((uint)src[j + 3]);
            }
        }

         static List<byte> toByteArray(List<uint> src)
        {
            byte[] dest = new byte[src.Count * 4];
            int pos = 0;

            for (int i = 0; i < src.Count; i++)
            {
                dest[pos++] = (byte)(src[i] >> 24);
                dest[pos++] = (byte)(src[i] >> 16);
                dest[pos++] = (byte)(src[i] >> 8);
                dest[pos++] = (byte)(src[i]);
            }

            return dest.ToList();
        }

         static uint RotateLeft(uint x, byte n)
        {
            return (x << n) | (x >> (32 - n));
        }

         static uint RotateRight(uint x, byte n)
        {
            //32 - n because of sha256 which uses 32 bit words
            return (x >> n) | (x << (32 - n));
        }

         static uint Ch(uint i, uint j, uint k)
        {
            return (i & j) ^ ((~i) & k);
        }

         static uint Maj(uint i, uint j, uint k)
        {
            return (i & j) ^ (i & k) ^ (j & k);
        }

        // velika sigma 0
         static uint BigSigma0(uint x)
        {
            return RotateRight(x, 2) ^ RotateRight(x, 13) ^ RotateRight(x, 22);
        }
        //velika sigma 1
         static uint BigSigma1(uint x)
        {
            return RotateRight(x, 6) ^ RotateRight(x, 11) ^ RotateRight(x, 25);
        }
        //mala sigma 0
         static uint SmallSigma0(uint x)
        {
            return RotateRight(x, 7) ^ RotateRight(x, 18) ^ (x >> 3);
        }
        //mala sigma 1
         static uint SmallSigma1(uint x)
        {
            return RotateRight(x, 17) ^ RotateRight(x, 19) ^ (x >> 10);
        }
    }
}
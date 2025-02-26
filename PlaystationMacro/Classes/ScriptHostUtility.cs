﻿// PlaystationMacro (File: Classes/ScriptHostUtility.cs)
//
// Copyright (c) 2018 Komefai
//
// Visit http://komefai.com for more information
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PlaystationMacro.Classes
{
    class ScriptHostUtility
    {
        public static byte[] ConvertAPIToInterceptorState(byte[] state)
        {
            var serialized = SerializeAPIState(state);
            return DeserializeInterceptorState(serialized);
        }

        public static byte[] ConvertInterceptorToAPIState(byte[] state)
        {
            var serialized = SerializeInterceptorState(state);
            return DeserializeAPIState(serialized);
        }

        public static string SerializeAPIState(byte[] state)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(byte[]));
            var sb = new StringBuilder();

            using (StringWriter writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, state);
                return sb.ToString();
            }
        }

        public static byte[] DeserializeAPIState(string data)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(byte[]));
            using (StringReader reader = new StringReader(data))
            {
                object obj = deserializer.Deserialize(reader);
                return obj as byte[];
            }
        }

        public static string SerializeInterceptorState(byte[] state)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(PS4RemotePlayInterceptor.DualShockState));
            var sb = new StringBuilder();

            using (StringWriter writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, state);
                return sb.ToString();
            }
        }

        public static byte[] DeserializeInterceptorState(string data)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(byte[]));
            using (StringReader reader = new StringReader(data))
            {
                object obj = deserializer.Deserialize(reader);
                return obj as byte[];
            }
        }

        #region Sequence
        public static List<byte[]> ConvertAPIToInterceptorSequence(List<byte[]> sequence)
        {
            var serialized = SerializeAPISequence(sequence);
            return DeserializeInterceptorSequence(serialized);
        }

        public static List<byte[]> ConvertInterceptorToAPISequence(List<byte[]> sequence)
        {
            var serialized = SerializeInterceptorSequence(sequence);
            return DeserializeAPISequence(serialized);
        }

        public static string SerializeAPISequence(List<byte[]> sequence)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<byte[]>));
            var sb = new StringBuilder();

            using (StringWriter writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, sequence);
                return sb.ToString();
            }
        }

        public static List<byte[]> DeserializeAPISequence(string data)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<byte[]>));
            using (StringReader reader = new StringReader(data))
            {
                object obj = deserializer.Deserialize(reader);
                return obj as List<byte[]>;
            }
        }

        public static string SerializeInterceptorSequence(List<byte[]> sequence)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<PS4RemotePlayInterceptor.DualShockState>));
            var sb = new StringBuilder();

            using (StringWriter writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, sequence);
                return sb.ToString();
            }
        }

        public static List<byte[]> DeserializeInterceptorSequence(string data)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<byte[]>));
            using (StringReader reader = new StringReader(data))
            {
                object obj = deserializer.Deserialize(reader);
                return obj as List<byte[]>;
            }
        }
        #endregion
    }
}

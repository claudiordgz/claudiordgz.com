using System;
using FluentAssertions;
using ContentManager.Util;
using System.Collections.Generic;
using Xunit;

namespace ContentManager.Test
{
    public class UrlValidationShould
    {
        [Theory]
        [MemberData(nameof(ValidUrls))]
        public void WillPassForValidUrls(string url)
        {
            bool result = UrlValidation.ValidHttpURL(url, out Uri uriResult);
            result.Should().BeTrue();
        }

        [Theory]
        [MemberData(nameof(InvalidUrls))]
        public void WillFailOnInvalidUrls(string url)
        {
            bool result = UrlValidation.ValidHttpURL(url, out Uri uriResult);
            result.Should().BeFalse();
        }

        public static IEnumerable<object[]> ValidUrls()
        {
            return new List<object[]> {
                new object[] { "https://www.google.com" },
                new object[] { "https://foo.com/blah_blah" },
                new object[] { "https://foo.com/blah_blah/" },
                new object[] { "https://foo.com/blah_blah_(wikipedia)" },
                new object[] { "https://foo.com/blah_blah_(wikipedia)_(again)" },
                new object[] { "https://www.example.com/wpstyle/?p=364" },
                new object[] { "https://foo.com/blah_(wikipedia)#cite-1" },
                new object[] { "https://foo.com/blah_(wikipedia)_blah#cite-1" },
                new object[] { "https://foo.com/unicode_(✪)_in_parens" },
                new object[] { "https://foo.com/(something)?after=parens" },
                new object[] { "https://code.google.com/events/#&product=browser" },
                new object[] { "https://j.mp" },
                new object[] { "https://foo.bar/?q=Test%20URL-encoded%20stuff" },
                new object[] { "https://1337.net" },
                new object[] { "https://a.b-c.de" },
                new object[] { "https://www.example.com/foo/?bar=baz&inga=42&quux" }
            };
        }

        public static IEnumerable<object[]> InvalidUrls()
        {
            return new List<object[]> {
                new object[] { "http://www.google.com" },
                new object[] { "www.google.com" },
                new object[] { "google.com" },
                new object[] { "http://foo.com/blah_blah" },
                new object[] { "http://foo.com/blah_blah/" },
                new object[] { "http://foo.com/blah_blah_(wikipedia)" },
                new object[] { "http://foo.com/blah_blah_(wikipedia)_(again)" },
                new object[] { "http://www.example.com/wpstyle/?p=364" },
                new object[] { "http://✪df.ws/123" },
                new object[] { "http://userid:password@example.com:8080" },
                new object[] { "http://userid:password@example.com:8080/" },
                new object[] { "http://userid@example.com" },
                new object[] { "http://userid@example.com/" },
                new object[] { "http://userid@example.com:8080" },
                new object[] { "http://userid@example.com:8080/" },
                new object[] { "http://userid:password@example.com" },
                new object[] { "http://userid:password@example.com/" },
                new object[] { "http://142.42.1.1/" },
                new object[] { "http://142.42.1.1:8080/" },
                new object[] { "http://➡.ws/䨹" },
                new object[] { "http://⌘.ws" },
                new object[] { "http://⌘.ws/" },
                new object[] { "http://foo.com/blah_(wikipedia)#cite-1" },
                new object[] { "http://foo.com/blah_(wikipedia)_blah#cite-1" },
                new object[] { "http://foo.com/unicode_(✪)_in_parens" },
                new object[] { "http://foo.com/(something)?after=parens" },
                new object[] { "http://☺.damowmow.com/" },
                new object[] { "http://code.google.com/events/#&product=browser" },
                new object[] { "http://j.mp" },
                new object[] { "http://foo.bar/?q=Test%20URL-encoded%20stuff" },
                new object[] { "http://مثال.إختبار" },
                new object[] { "http://例子.测试" },
                new object[] { "http://उदाहरण.परीक्ष" },
                new object[] { "http://-.~_!$&'()*+,;=:%40:80%2f::::::@example.com" },
                new object[] { "https://-.~_!$&'()*+,;=:%40:80%2f::::::@example.com" },
                new object[] { "http://1337.net" },
                new object[] { "http://a.b-c.de" },
                new object[] { "http://223.255.255.254" },
                new object[] { "https://" },
                new object[] { "https://." },
                new object[] { "https://.." },
                new object[] { "https://../" },
                new object[] { "https://?" },
                new object[] { "https://??" },
                new object[] { "https://??/" },
                new object[] { "https://#" },
                new object[] { "https://##" },
                new object[] { "https://##/" },
                new object[] { "https://foo.bar?q=Spaces should be encoded" },
                new object[] { "//" },
                new object[] { "//a" },
                new object[] { "///a" },
                new object[] { "///" },
                new object[] { "https:///a" },
                new object[] { "foo.com" },
                new object[] { "rdar://1234" },
                new object[] { "h://test" },
                new object[] { "https:// shouldfail.com" },
                new object[] { ":// should fail" },
                new object[] { "http://foo.bar/foo(bar)baz quux" },
                new object[] { "ftps://foo.bar/" },
                new object[] { "https://-error-.invalid/" },
                new object[] { "http://a.b--c.de/" },
                new object[] { "https://-a.b.co" },
                new object[] { "http://a.b-.co" },
                new object[] { "http://0.0.0.0" },
                new object[] { "http://10.1.1.0" },
                new object[] { "http://10.1.1.255" },
                new object[] { "http://224.1.1.1" },
                new object[] { "https://1.1.1.1.1" },
                new object[] { "http://123.123.123" },
                new object[] { "http://3628126748" },
                new object[] { "http://.www.foo.bar/" },
                new object[] { "http://www.foo.bar./" },
                new object[] { "http://.www.foo.bar./" },
                new object[] { "http://10.1.1.1" },
                new object[] { "http://10.1.1.254" },
                new object[] { "javascript:alert('Hack me!')" }
            };
        }
    }
}

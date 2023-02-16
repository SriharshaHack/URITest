let chars = []
let chars_pretty = []
const base = "https://base.com"for (let i = 0x0000; i<= 0x10FFFF; i++) {
    try {        
        const fake_url = new URL(`${String.fromCodePoint(i)}///foo`, base);
        // if the attack is successful - we'll substitute the base with our string        if (fake_url.origin != base) {
            chars.push(Number(i).toString(16).padStart(4, "0")); // hexadecimal val            chars_pretty.push(String.fromCodePoint(i)); // displayable character         }
    } catch (e) {
        // some chars may cause URL() to throw - let's skip them    }
}
console.log(chars.join(', '));
console.log(chars_pretty.join(', '));

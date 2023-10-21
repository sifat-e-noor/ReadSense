import { Nunito_Sans } from 'next/font/google'
 
// If loading a variable font, you don't need to specify the font weight
const inter = Nunito_Sans({ subsets: ['latin'] })
 
export default function MyApp({ Component, pageProps }) {
  return (
    <main className={inter.className}>
      <Component {...pageProps} />
    </main>
  )
}
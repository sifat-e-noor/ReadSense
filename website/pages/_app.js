import { Nunito_Sans } from 'next/font/google'
import { SessionProvider } from "next-auth/react"
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import React from "react";
 
// If loading a variable font, you don't need to specify the font weight
const inter = Nunito_Sans({ subsets: ['latin'] })
 
export default function App({ 
  Component, 
  pageProps: { session, ...pageProps },
 }) {

  return (
    <>
      <SessionProvider session={session}>
        <main className={inter.className}>
          <Component {...pageProps} />
        </main>
      </SessionProvider>
      <ToastContainer
          position="top-right"
          autoClose={8000}
          hideProgressBar={false}
          newestOnTop={false}
          draggable={false}
          pauseOnVisibilityChange
          closeOnClick
          pauseOnHover
        />
    </>
    
    
  )
}
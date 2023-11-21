import NextAuth, { NextAuthOptions, Session }  from "next-auth"
import { JWT } from "next-auth/jwt";
import CredentialsProvider from "next-auth/providers/credentials"

export const authOptions : NextAuthOptions = {
  // Configure one or more authentication providers
  providers: [
    CredentialsProvider({
      // The name to display on the sign in form (e.g. "Sign in with...")
      name: "Credentials",
      // `credentials` is used to generate a form on the sign in page.
      // You can specify which fields should be submitted, by adding keys to the `credentials` object.
      // e.g. domain, username, password, 2FA token, etc.
      // You can pass any HTML attribute to the <input> tag through the object.
      credentials: {
        username: { label: "Username", type: "text", placeholder: "jsmith" },
        password: { label: "Password", type: "password" },
        deviceInfo: { label: "Device Info", type: "text" },
        fingerPrint: { label: "Device Info", type: "text" }
      },
      async authorize(credentials, req) {
        const { username, password, deviceInfo, fingerPrint } = credentials as any;
        const url = process.env.NEXT_PUBLIC_READSENSE_API_URL+"/api/Users/authenticate"
        const response = await fetch(url, {
          method: "POST",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify({ username, password, deviceInfo, fingerPrint })
        });
        
        const user = await response.json();

        if(response.ok && user) {
          return user;
        } else {
          return null;
        }
      }
    })
  ],

  session: {
    strategy: "jwt",
  },
  callbacks: {
    async signIn({ user, account, profile, email, credentials }) {
      const isAllowedToSignIn = true
      if (isAllowedToSignIn) {
        return true
      } else {
        // Return false to display a default error message
        return false
        // Or you can return a URL to redirect to:
        // return '/unauthorized'
      }
    },
    async jwt({ token, user }) {
      if (user) {
        return { ...token, ...user };
      }

      
      // on subsequent calls, token is provided and we need to check if it's expired. Though backend does not return refresh token
      // if (token?.accessTokenExpires) {
      //   if (Date.now() / 1000 < token?.accessTokenExpires) return { ...token, ...user };
      // } else if (token?.refreshToken) return refreshAccessToken(token);

      return token;
    },
    async session({ session, token }: { session: Session; token: JWT }) {
      // Send properties to the client, like an access_token from a provider.
      console.log(token?.accessTokenExpires, Date.now() / 1000)
      if ( token?.accessTokenExpires && Date.now() / 1000 > token?.accessTokenExpires) {
        return Promise.reject({
          error: new Error("Token has expired. Please log in again to get a new refresh token."),
        });
      }

      session.token = token.token as string
      
      const user : Session["user"] =  {
        id: token.id as string,
        email: token.userName as string,
        agreementSigned: token.agreementSigned as boolean
      }

      const accessTokenData = JSON.parse(atob(token.token.split(".")?.at(1) as string));

      session.user = { ...user ,...accessTokenData };
      token.accessTokenExpires = accessTokenData.exp;

      session.token = token?.token;
      return session;
    },
  },
  pages: {
    signIn: "/login",
  }
}

export default NextAuth(authOptions)

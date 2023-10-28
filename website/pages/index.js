
import { signIn, useSession } from "next-auth/react";
import { useEffect } from "react";
import { useRouter } from "next/router";

export default function Landing() {
  const router = useRouter();
  const { status, data: session } = useSession();

  useEffect(() => {
    if (status === "unauthenticated") {
      console.log("No JWT");
      console.log(status);
      void signIn();
    } else if (status === "authenticated") {
      if(session.user.agreementSigned){
        router.push("/existingUserContext");
      } else {
        var agreementSigned = getUserAgreement(session.user.id);
        if(agreementSigned){
          router.push("/existingUserContext");
        } else {
          router.push("/newUserIntro");
        }
      }
    }
  }, [status]);

  const getUserAgreement = async (id) => {
    let response = undefined;
    try {
      response = await fetch("http://localhost:5298/api/users/"+id, {
        headers: {
          "Content-Type": "application/json",
          Authorization: "Bearer " + session.accessToken,
        },
        method: "GET",
      });
    }
    catch (error) {
      console.error("An unexpected error happened occurred:", error);
      return false;
    }

    if (response?.status === 200) {
      const data = await response.json();
      return data.agreementSigned;
    } else {
      return false;
    }
  };
  return <div>loading....</div>;
}
